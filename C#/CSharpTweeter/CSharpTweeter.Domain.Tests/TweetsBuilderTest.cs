using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class TweetsBuilderTest
    {
        private string GetTextFromFile(string path)
        {
            var fileText = File.ReadAllText(path);
            return fileText;
        }


        [TestMethod]
        public void Create_WhereTweetsExist_ReturnsAListOfTweets()
        {
            var tweetPath = GetTextFromFile(ConfigurationManager.AppSettings["OneTweetPath"]);
            var tweets = TweetsBuilder.Create(tweetPath);

            Assert.AreEqual(1, tweets.Count);
            Assert.AreEqual("Alan", tweets[0].Name);
            Assert.AreEqual("If you have a procedure with 10 parameters, you probably missed some.", tweets[0].Text);

        }

        [TestMethod]
        public void Create_WhereThreeTweetsExists_ReturnsThreeTweets()
        {
            var tweetPath = GetTextFromFile(ConfigurationManager.AppSettings["TweetFilePath"]);
            var tweets = TweetsBuilder.Create(tweetPath);

            Assert.AreEqual(3, tweets.Count);

        }

    }
}
