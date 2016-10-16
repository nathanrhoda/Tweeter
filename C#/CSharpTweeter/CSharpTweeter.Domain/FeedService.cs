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

        public object GetFeedBy(User user)
        {
            var fileText = File.ReadAllText(_tweetFilePath);
            throw new NotImplementedException("Implement Get Feeds By User");

        }
    }
}