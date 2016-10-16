using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class FeedServiceTest
    {
        [TestMethod, Ignore]
        public void GetTweetsByUser_WhereTweetsExists_ReturnsTweets()
        {
            var user = new User();
            var filePath = ConfigurationManager.AppSettings["TweetFilePath"];
            
            var service = new FeedService(filePath);
            var feed = service.GetFeedBy(user);

            Assert.IsNotNull(feed);
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Initialize_WhereInputIsNotValid_ThrowsException()
        {
            var service = new FeedService("");
        }
    }
}
