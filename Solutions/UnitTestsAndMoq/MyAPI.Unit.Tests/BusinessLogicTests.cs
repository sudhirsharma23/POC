using FluentAssertions;

namespace MyAPI.Unit.Tests
{
    public class BusinessLogicTests
    {
        private BusinessLogic _businessLogic;
        private List<string> _albums;
        private string _nextAlbum;

        [Fact]
        public void GetAlbumsReturnsTwoAlbums()
        {
            GivenBusinessLogic();

            WhenGetAlbumsIsCalled();

            ThenAlbumsContainsTwoU2Albums();
        }

        [Fact]
        public void GetNextAlbumReturnsFirstAlbum()
        {
            GivenBusinessLogic();

            WhenGetNextAlbumIsCalled();

            ThenAlbumIsFirstAlbum();
        }

        private void GivenBusinessLogic()
        {
            _businessLogic = new BusinessLogic();
        }

        private void WhenGetAlbumsIsCalled()
        {
            _albums = _businessLogic.GetAlbums("Random artist");
        }

        private void WhenGetNextAlbumIsCalled()
        {
            _nextAlbum = _businessLogic.GetNextAlbum("Random artist", "Random fan");
        }

        private void ThenAlbumsContainsTwoU2Albums()
        {
            _ = _albums.Count.Should().Be(2);
            _ = _albums[0].Should().Be("The Unforgettable Fire");
            _ = _albums[1].Should().Be("The Joshua Tree");
        }

        private void ThenAlbumIsFirstAlbum()
        {
            _ = _nextAlbum.Should().Be("The Unforgettable Fire");
        }
    }
}