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


            var userService = new UserService(userFilePath);
            var users = userService.GetUsers();

            foreach (var user in users.Users)
            {
                System.Console.WriteLine(user.Name);

                var tweetService = new TweetService(tweetFilePath);
                //var feed = tweetService.GetFeedBy(user);

                //System.Console.WriteLine(feed.ToString());
            }

            System.Console.ReadLine();


        }
    }
}
