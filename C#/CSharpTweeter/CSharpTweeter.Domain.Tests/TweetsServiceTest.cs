using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class TweetsServiceTest
    {
        [TestMethod]
        public void GetTweets_WhereFeedsExist_ReturnsAListOfFeeds()
        {
            var service = new TweetsService();
            var tweets = service.GetTweets();
            Assert.IsNotNull(tweets);
        }
    }

    public class TweetsService
    {
        public object GetTweets()
        {
            return new object();  
            
            
                      
        }
    }
}
