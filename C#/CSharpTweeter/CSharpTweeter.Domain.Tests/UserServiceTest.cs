using System;
using System.Collections.Generic;
using System.Configuration;
using CSharpTweeter.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod, Ignore]
        public void GetTweets_WhereFeedsExist_ReturnsMoreThanZeroTweets()
        {
            var service = TweetsServiceFactory.Tweets(); 
            var tweets = service.GetTweets();
            Assert.IsTrue(tweets.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Initialize_WhereInputIsNotValid_ThrowsException()
        {
            var service = TweetsServiceFactory.InvalidInputFiles();            
                        
        }

        [TestMethod]
        public void Initialize_WhereInputIsValid_ReturnsUsersAndTweets()
        {
            var service = TweetsServiceFactory.Tweets();

            Assert.IsTrue(service.Tweets.Count > 0);
            Assert.IsTrue(service.Users.Count > 0);
        }
      
    }    
}


public static class TweetsServiceFactory
{
    public static UserService InvalidInputFiles()
    {
        return new UserService("", "");
    }

    public static UserService Tweets()
    {
        var tweetsFilePath = ConfigurationManager.AppSettings["TweetFilePath"];
        var userFilePath = ConfigurationManager.AppSettings["UserFilePath"];
        return new UserService(tweetsFilePath, userFilePath);
    }

}