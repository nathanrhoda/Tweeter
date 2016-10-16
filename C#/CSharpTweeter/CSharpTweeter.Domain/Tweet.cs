using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTweeter.Domain
{
    public class Tweet
    {
        public string Name { get; set; }

        public string Text { get; set; }
    }

    public class TweetList
    {
        public TweetList()
        {
            Tweets = new List<Tweet>();
        }

        public List<Tweet> Tweets { get; private set; }


        public Tweet this[int index]
        {
            get { return Tweets[index]; }
        }

        public int Count
        {
            get { return Tweets.Count; }

        }
        public void AddTweet(Tweet tweet)
        {
            if (!this.Tweets.Contains(tweet))
            {
                this.Tweets.Add(tweet);
            }
        }


    }
}
