using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpTweeter.Domain;

namespace CSharpTweeter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Tweet Tweet");

            var tweetFilePath = ConfigurationManager.AppSettings["TweetFilePath"];
            var userFilePath = ConfigurationManager.AppSettings["UserFilePath"];


            //var userService = new UserService();
            //var users = userService.GetUsers();

            //foreach (var user in users)
            //{
            //    var tweetService = new TweetsService();
            //    var feed = tweetService.GetFeedByUser(user);
            //    System.Console.WriteLine(feed.ToString());
            //}


            System.Console.ReadLine();


        }
    }
}
