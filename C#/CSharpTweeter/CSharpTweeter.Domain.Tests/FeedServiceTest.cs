using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class FeedServiceTest
    {
        /// <summary>
        /// <file>
        ///  <key>TweetFilePath</key>
        ///  <text>         
        ///  Alan> If you have a procedure with 10 parameters, you probably missed some.
        ///  Ward> There are only two hard things in Computer Science: cache invalidation, naming things and off-by-1 errors.
        ///  Alan> Random numbers should not be generated with a method chosen at random.
        /// </text>
        /// </file>
        /// </summary>
        [TestMethod]
        public void GetFeedBy_WhereTweetsExists_ReturnsTweets()
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
            var service = new FeedService("Master Path");
        }

        /// <summary>
        /// <file>
        ///  <key>OneTweetPath</key>
        ///  <text>         
        ///  Alan> If you have a procedure with 10 parameters, you probably missed some.
        /// </text>
        /// </file>
        /// </summary>
        [TestMethod]
        public void GetFeedBy_WhereUserHasOneTweet_ReturnsFeedWithOneTweet()
        {
            var user = new User
            {
                Name = "Alan"
            };

            var filePath = ConfigurationManager.AppSettings["OneTweetPath"];

            var service = new FeedService(filePath);

            var feed = service.GetFeedBy(user);

            Assert.IsNotNull(feed);
            Assert.AreEqual(1, feed.Items.Count);

        }

        /// <summary>
        /// <file>
        ///  <key>TweetFilePath</key>
        ///  <text>         
        ///  Alan> If you have a procedure with 10 parameters, you probably missed some.
        ///  Ward> There are only two hard things in Computer Science: cache invalidation, naming things and off-by-1 errors.
        ///  Alan> Random numbers should not be generated with a method chosen at random.
        /// </text>
        /// </file>
        /// </summary>
        [TestMethod]
        public void GetFeedBy_WhereUserHasTwoTweetsAndPersonHisFollowingHasOneTweet_ReturnsFeedWithThreeTweets()
        {
            var alan = new User
            {
                Name = "Alan",                
            };

            var ward = new User
            {
                Name = "Ward"
            };

            alan.Following.AddUser(ward);

            var filePath = ConfigurationManager.AppSettings["TweetFilePath"];

            var service = new FeedService(filePath);

            var feed = service.GetFeedBy(alan);

            Assert.IsNotNull(feed);
            Assert.AreEqual(3, feed.Items.Count);
        }

    }
}
