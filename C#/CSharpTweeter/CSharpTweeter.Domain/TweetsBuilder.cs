using System;
using System.Collections.Generic;

namespace CSharpTweeter.Domain
{
    public class TweetsBuilder
    {
        public static TweetList Create(string texts)
        {
            var tweetList = new TweetList();

            foreach (var tweetText in texts.Split('\n'))
            {
                if (!String.IsNullOrEmpty(tweetText))
                {
                    var tweetParse = tweetText.Replace("> ", "|").Split('|');
                    var userName = tweetParse[0];
                    var value = tweetParse[1].Trim('\r');

                    var tweet = new Tweet
                    {
                        Name = userName,
                        Text = value
                    };

                    tweetList.AddTweet(tweet);
                }
            }

            return tweetList;

        }
    }
}