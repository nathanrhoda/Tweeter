using System;
using System.IO;

namespace CSharpTweeter.Domain
{
    public class FeedService
    {
        private string _tweetFilePath;
        
        public FeedService(string tweetFilePath)
        {
            if (!File.Exists(tweetFilePath))
            {
                throw new FileNotFoundException(string.Format("File does not exist {0}", tweetFilePath));
            }
            this._tweetFilePath = tweetFilePath;
        }

        public Feed GetFeedBy(User user)
        {
            var feed = new Feed();
            var fileText = File.ReadAllText(_tweetFilePath);
            var tweets = TweetsBuilder.Create(fileText);

            foreach (var tweet in tweets.Tweets)
            {
                if (tweet.Name == user.Name || user.Following.Users.Exists(x=>x.Name.Equals(tweet.Name)))
                {
                    feed.Items.Add(tweet);
                }
            }
            

            return feed;
        }
    }
}