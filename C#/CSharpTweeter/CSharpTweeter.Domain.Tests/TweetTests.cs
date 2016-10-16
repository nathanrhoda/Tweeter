using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class TweetTests
    {
        [TestMethod]
        public void Tweet_CreateAndSetTweet_SetsAndGetsRelevantValues()
        {
            var tweet = new Tweet
            {
                Name = "First",
                Text = "Tweet"
            };

            var secondTweet = new Tweet
            {
                Name = tweet.Name,
                Text = tweet.Text
            };

            Assert.AreEqual(secondTweet.ToString(), tweet.ToString());
        }
    }
}
