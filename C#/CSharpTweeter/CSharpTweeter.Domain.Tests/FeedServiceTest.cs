using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class FeedServiceTest
    {
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
            var service = new FeedService("");
        }

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

        [TestMethod]
        public void GetFeedBy_WhereUserHasTwoTweetsAndPersonHisFollowingHasOneTweet_ReturnsFeedWithThreeTweets()
        {
            var user = new User
            {
                Name = "Alan",                
            };

            var follower = new User
            {
                Name = "Ward"
            };

            user.Followers.AddUser(follower);

            var filePath = ConfigurationManager.AppSettings["TweetFilePath"];

            var service = new FeedService(filePath);

            var feed = service.GetFeedBy(user);

            Assert.IsNotNull(feed);
            Assert.AreEqual(3, feed.Items.Count);
        }

        //[TestMethod]
        //public void GetFeedBy_WhereUserHasOneTweetAndIsFollowingOnePersonWithNoTweets_ReturnsOneTweet()
        //{
            

        //}

        //[TestMethod]
        //public void GetFeedBy_WhereUserHasNoTweetsAndIsFollowingNoOne_ReturnsEmptyFeed()
        //{
        //}
    }
}
