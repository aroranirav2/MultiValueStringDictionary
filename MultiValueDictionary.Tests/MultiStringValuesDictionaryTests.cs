using Xunit;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MultiValueDictionary.Tests
{
    public class MultiStringValuesDictionaryTests
    {
        private readonly MultiStringValuesDictionary _dictionary;
        public MultiStringValuesDictionaryTests()
        {
            _dictionary = new MultiStringValuesDictionary();
        }
        [Fact]
        public void Should_Add_Multiple_Values_To_Key_In_Dictionary()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            Assert.Collection(_dictionary.Keys, item => Assert.Equal("foo", item));
        }
        [Fact]
        public void Should_Throw_Invalid_Operation_For_Adding_To_Dictionary()
        {
            _dictionary.Add("foo", "bar");
            Assert.Throws<InvalidOperationException>(() => _dictionary.Add("foo", "bar"));
        }
        [Fact]
        public void Should_Add_New_Key_New_Value()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("bang", "baz");
            Assert.Collection<string>(_dictionary.Keys,
                item => Assert.Equal("foo", item),
                item => Assert.Equal("bang", item)
                );
        }
        [Fact]
        public void Should_Get_All_Members_For_A_Key()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            var members = _dictionary.Members("foo");
            Assert.Equal(2, members.Count);
            _dictionary.Add("foo", "bang");
            Assert.Collection<string>(_dictionary.Members("foo"),
                item => Assert.Equal("bar", item),
                item => Assert.Equal("baz", item),
                item => Assert.Equal("bang", item)
                );
        }
        [Fact]
        public void Should_Throw_Key_Not_Found_Exception_For_Members()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            Assert.Equal(2, _dictionary.Members("foo").Count);
            Assert.Throws<KeyNotFoundException>(() => _dictionary.Members("bang"));
        }
        [Fact]
        public void Should_Get_All_Keys()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            _dictionary.Add("bang", "bar");
            var keys = _dictionary.Keys;
            Assert.Equal(2, keys.Count);
            Assert.Equal(new List<string> { "foo", "bang" }, keys.ToList());
            Assert.Collection<string>(keys,
                item => Assert.Equal("foo", item),
                item => Assert.Equal("bang", item)
                );
        }
        [Fact]
        public void Should_Keys_Be_Empty_Collection()
        {
            var keys = _dictionary.Keys;
            Assert.Equal(0, keys.Count);
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            _dictionary.Clear();
            keys = _dictionary.Keys;
            Assert.Equal(0, keys.Count);
        }
        [Fact]
        public void Should_Remove_Key()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            _dictionary.Add("bang", "bar");
            var keys = _dictionary.Keys;
            Assert.Equal(2, keys.Count);
            _dictionary.Remove("foo");
            keys = _dictionary.Keys;
            Assert.Equal(1, keys.Count);
            _dictionary.Remove("bang");
            keys = _dictionary.Keys;
            Assert.Equal(0, keys.Count);
        }
        [Fact]
        public void Should_Throw_Key_Not_Found_Exception_For_Remove()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            var keys = _dictionary.Keys;
            Assert.True(keys.Contains("foo"));
            Assert.Throws<KeyNotFoundException>(() => _dictionary.Remove("bang", "bar"));
            _dictionary.Remove("foo");
            Assert.Throws<KeyNotFoundException>(() => _dictionary.Remove("foo"));
        }
        [Fact]
        public void Should_Remove_Member_From_Key()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            Assert.Collection<string>(_dictionary.Members("foo"),
                item => Assert.Equal("bar", item),
                item => Assert.Equal("baz", item)
                );
        }
        [Fact]
        public void Should_Remove_Key_From_Member()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            Assert.True(_dictionary.Keys.Contains("foo"));
            _dictionary.Remove("foo", "bar");
            Assert.True(_dictionary.Keys.Contains("foo"));
            _dictionary.Remove("foo", "baz");
            Assert.False(_dictionary.Keys.Contains("foo"));
        }
        [Fact]
        public void Should_Throw_Key_Not_Found_Exception_For_Remove_Member()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            Assert.True(_dictionary.Keys.Contains("foo"));
            _dictionary.Remove("foo", "bar");
            Assert.True(_dictionary.Keys.Contains("foo"));
            _dictionary.Remove("foo", "baz");
            Assert.Throws<KeyNotFoundException>(() => _dictionary.Remove("foo", "bar"));
        }
        [Fact]
        public void Should_Throw_Member_Not_Found_Exception()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            Assert.Throws<ArgumentException>(() => _dictionary.Remove("foo", "bang"));
        }
        [Fact]
        public void Should_Clear_Dictionary()
        {
            _dictionary.Add("foo", "bar");
            _dictionary.Add("foo", "baz");
            Assert.Equal(1, _dictionary.Keys.Count);
            _dictionary.Add("bang", "bar");
            Assert.Equal(2, _dictionary.Keys.Count);
            var allMembers = _dictionary.AllMembers();
            Assert.Equal(2, allMembers.Count);
            _dictionary.Clear();
            allMembers = _dictionary.AllMembers();
            Assert.False(allMembers.Any());
            Assert.False(_dictionary.Keys.Any());
        }
    }
}
