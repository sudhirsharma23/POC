using FluentAssertions;
using Moq;

namespace MyAPI.Unit.Tests
{
    public class AlbumControllerTests
    {
        private const string NeedMoreRAMExceptionText = "Need more RAM";
        private const string MissingArtistName = "Missing artistName argument";

        private readonly List<string> U2Albums = new()
        {
                "The Unforgettable Fire",
                "The Joshua Tree",
                "Greatest Hits"
        };

        private readonly Mock<IBusinessLogic> _mockBusinessLogic = new();
        private readonly Mock<IMemoryCache> _mockCache = new();
        private readonly AlbumController _controller;
        private readonly Dictionary<string, object> _cachedItems = new();
        private readonly List<Exception> _exceptions = new();

        private IEnumerable<string>? _getAlbumsResult;
        private string? _getNextAlbumResult;
        private int _albumCount;
        private int _removeCacheKeyAttempts;

        public AlbumControllerTests()
        {
            _controller = new AlbumController(_mockBusinessLogic.Object, _mockCache.Object);
        }

        [Fact]
        public void GetAlbumsReturnsMockedList()
        {
            GivenBusinessLogicIsCalledReturnU2Albums();

            WhenGetAlbumsIsCalled();

            ThenVerifyAlbumsAreAsExpected();
            ThenVerifyMockSetupsAreCalled();
        }

        [Fact]
        public void GetAlbumsThrowsFromBusinessLogicException()
        {
            GivenBusinessLogicIsCalledThrowException();

            WhenGetAlbumsIsCalled();

            ThenVerifyOneExceptionWasThrown<ArgumentException>(MissingArtistName);
            ThenVerifyMockSetupsAreCalled();
        }

        [Fact]
        public void GetNextAlbumsRetrievesFirst()
        {
            GivenGetNextAlbumReturnsAlbumsConsecutively();

            WhenGetNextAlbumIsCalled();

            ThenVerifyNextAlbumIs(U2Albums[0]);
            ThenVerifyMockSetupsAreCalled();
        }

        [Fact]
        public void GetNextAlbumsRetrievesSecond()
        {
            GivenGetNextAlbumReturnsAlbumsConsecutively();

            WhenGetNextAlbumIsCalled();
            WhenGetNextAlbumIsCalled();

            ThenVerifyNextAlbumIs(U2Albums[1]);
            ThenVerifyMockSetupsAreCalled();
        }

        [Fact]
        public void GetNextAlbumsRetrievesThird()
        {
            GivenGetNextAlbumReturnsAlbumsConsecutively();

            WhenGetNextAlbumIsCalled();
            WhenGetNextAlbumIsCalled();
            WhenGetNextAlbumIsCalled();

            ThenVerifyNextAlbumIs(U2Albums[2]);
            ThenVerifyMockSetupsAreCalled();
        }

        [Fact]
        public void RemoveCacheKeyThrowsOnFifthAttempt()
        {
            GivenRemoveCacheKeyThrowsOnFifthAttempt();

            WhenRemoveCacheKeyIsCalled();
            WhenRemoveCacheKeyIsCalled();
            WhenRemoveCacheKeyIsCalled();
            WhenRemoveCacheKeyIsCalled();
            WhenRemoveCacheKeyIsCalled();

            ThenVerifyOneExceptionWasThrown<OutOfMemoryException>(NeedMoreRAMExceptionText);
            ThenVerifyMockSetupsAreCalled();
        }

        private void GivenRemoveCacheKeyThrowsOnFifthAttempt()
        {
            _ = _mockCache.Setup(f => f.Remove(It.IsAny<string>())).Callback(() =>
            {
                _removeCacheKeyAttempts++;
                if (_removeCacheKeyAttempts < 5)
                {
                    return; // cache remove is fine
                }

                throw new OutOfMemoryException(NeedMoreRAMExceptionText);
            });
        }

        [Fact]
        public void AddToCachePersistsInFakeMock()
        {
            // arrange
            _mockCache.Setup(f => f.Add(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((s, o) =>
                {
                    _cachedItems.Add(s, o);
                }); // GivenAddStoresTheObjectInFakeCache

            _mockCache.Setup(f => f.Keys()).Returns(() =>
            {
                return _cachedItems.Keys.ToList();
            }); // GivenKeysRetrievesFakeCacheKeys

            // act
            _controller.AddToCache("bark", "woof"); //WhenAddToCacheIsCalled
            var keys = _controller.CacheKeys(); // WhenCacheKeysIsCalled


            // assert
            keys.Count.Should().Be(1); // ThenItemCountShouldBe(1)
            keys.First().Should().Be("bark"); // ThenFirstKeyShouldBe("bark")

            _mockBusinessLogic.VerifyAll(); // ThenVerifyMockSetupsAreCalled();
        }

        [Fact]
        public void AddToCacheAndRemoveFromCacheHasStateInFakeMock()
        {
            // arrange
            _mockCache.Setup(f => f.Add(It.IsAny<string>(), It.IsAny<object>()))
                .Callback<string, object>((s, o) =>
                {
                    _cachedItems.Add(s, o);
                });

            _mockCache.Setup(f => f.Remove(It.IsAny<string>())).Callback<string>((s) =>
            {
                _cachedItems.Remove(s);
            });

            _mockCache.Setup(f => f.Keys()).Returns(() =>
            {
                return _cachedItems.Keys.ToList();
            });

            // act
            _controller.AddToCache("bark", "woof");
            _controller.RemoveFromCache("bark");
            var keys = _controller.CacheKeys();

            // assert
            keys.Count.Should().Be(0);
        }

        private void GivenGetNextAlbumReturnsAlbumsConsecutively()
        {
            _mockBusinessLogic.Setup(f => f.GetNextAlbum(It.IsAny<string>(), It.IsAny<string>())).Returns(() =>
            {
                var albumName = string.Empty;

                albumName = _albumCount switch
                {
                    0 => U2Albums[0],
                    1 => U2Albums[1],
                    _ => U2Albums[2],
                };

                _albumCount++;
                return albumName;
            });
        }

        private void GivenBusinessLogicIsCalledReturnU2Albums()
        {
            _mockBusinessLogic.Setup(f => f.GetAlbums(It.IsAny<string>())).Returns(U2Albums);
        }

        private void GivenBusinessLogicIsCalledThrowException()
        {
            _mockBusinessLogic.Setup(f => f.GetAlbums(It.IsAny<string>())).Throws(new ArgumentException(MissingArtistName));
        }

        private void WhenRemoveCacheKeyIsCalled()
        {
            var ex = Record.Exception(() => _controller.RemoveFromCache("a key"));
            if (ex != null)
            {
                _exceptions.Add(ex);
            }
        }

        private void WhenGetAlbumsIsCalled()
        {
            var ex = Record.Exception(() => _getAlbumsResult = _controller.Get("U2"));
            if (ex != null)
            {
                _exceptions.Add(ex);
            }
        }

        private void WhenGetNextAlbumIsCalled()
        {
            _getNextAlbumResult = _controller.GetNextAlbum("U2", "Jane Doe");
        }

        private void ThenVerifyOneExceptionWasThrown<T>(string exceptionMessage)
        {
            _ = _exceptions.Count.Should().Be(1);

            var ex = _exceptions.FirstOrDefault();

            ex.Should().NotBeNull();
            ex.Should().BeOfType<T>();
            ex.Message.Should().Be(exceptionMessage);
        }

        private void ThenVerifyMockSetupsAreCalled()
        {
            _mockBusinessLogic.VerifyAll();
        }

        private void ThenVerifyAlbumsAreAsExpected()
        {
            _getAlbumsResult.Should().BeEquivalentTo(U2Albums);
        }

        private void ThenVerifyNextAlbumIs(string albumName)
        {
            _getNextAlbumResult.Should().Be(albumName);
        }
    }
}