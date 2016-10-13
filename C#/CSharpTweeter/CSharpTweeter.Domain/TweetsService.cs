using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpTweeter.Domain
{
    public class TweetsService
    {
        private string _tweetsFilePath;
        private string _userFilePath;

        public TweetsService(string tweetsFilePath, string userFilePath)
        {
            this._tweetsFilePath = tweetsFilePath;
            this._userFilePath = userFilePath;
            Users = new List<object>();
            Tweets = new List<object>();

            Intialize();
        }

        internal List<object> Tweets { get; set; }
        internal List<object> Users { get; set; }

        public List<object> GetTweets()
        {
            return new List<object>();
        }

        public void Intialize()
        {
            Users = BuildUsers();
            Tweets = BuildTweets();

        }

        private List<object> BuildUsers()
        {
            try
            {
                var userList = new List<object>();

                var fileText = File.ReadAllText(_userFilePath);

                if (!string.IsNullOrEmpty(fileText))
                {
                    var user = new object();
                    userList.Add(user);
                }


                return userList;
            }
            catch
            {
                throw new Exception(string.Format("Invalid User File Path: {0}", _userFilePath));
            }

        }

        private List<object> BuildTweets()
        {
            try
            {
                var tweetList = new List<object>();
                var fileText = File.ReadAllText(_tweetsFilePath);

                if (!string.IsNullOrEmpty(fileText))
                {
                    var tweet = new object();
                    tweetList.Add(tweet);
                }

                return tweetList;
            }
            catch
            {
                throw new Exception(string.Format("Invalid Tweet File Path: {0}", _tweetsFilePath));
            }
        }
    }
}
