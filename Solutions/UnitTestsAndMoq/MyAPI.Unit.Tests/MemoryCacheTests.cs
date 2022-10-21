using FluentAssertions;

namespace MyAPI.Unit.Tests
{
    public class MemoryCacheTests
    {
        private MemoryCache _cache;
        private List<string> _keys;

        [Fact]
        public void AddPersistsKeyWhenCallingKeys()
        {
            GivenAMemoryCache();

            WhenAddIsCalled("foo", "bar");
            WhenKeysIsCalled();

            ThenKeyIsFoo();
        }

        [Fact]
        public void RemoveDeletesAddedKey()
        {
            GivenAMemoryCache();

            WhenAddIsCalled("foo", "bar");
            WhenRemoveIsCalled("foo");
            WhenKeysIsCalled();

            ThenZeroKeysExist();
        }

        private void GivenAMemoryCache()
        {
            _cache = new MemoryCache();
        }

        private void WhenKeysIsCalled()
        {
            _keys = _cache.Keys();
        }

        private void WhenAddIsCalled(string key, object value)
        {
            _cache.Add(key, value);
        }

        private void WhenRemoveIsCalled(string key)
        {
            _cache.Remove(key);
        }

        private void ThenKeyIsFoo()
        {
            _ = _keys.Count.Should().Be(1);
            _ = _keys[0].Should().Be("foo");
        }

        private void ThenZeroKeysExist()
        {
            _ = _keys.Count.Should().Be(0);
        }
    }
}