using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class UserBuilderTest
    {

        private string GetUsersFromFile(string path)
        {            
            var fileText = File.ReadAllText(path);
            return fileText;
        }


        [TestMethod]
        public void Create_WhereStringWithTwoUniqueUsersSupplied_ReturnsTwoUsers()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["UserFilePath"]);
            var usersList = UserBuilder.Create(users);

            Assert.AreEqual(3, usersList.Count);
        }

        [TestMethod]
        public void Create_WhereOneFollowerExists_ReturnsUserWithOneFollower()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["OneFollowerPath"]);
            var userList = UserBuilder.Create(users);

            var user = userList[1];
            var follower = user.Followers[0];

            Assert.AreEqual("Ward", follower.Name);
            Assert.AreEqual("Alan", user.Name);

        }

        [TestMethod]
        public void Create_WhereTwoFollowerExists_ReturnsUserWithTwoFollowers()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["TwoFollowerPath"]);
            var userList = UserBuilder.Create(users);

            var alan = userList[2];
            var martin = userList[1];
            var wardFollowingAlan = alan.Followers[0];
            var wardFollowingMartin = martin.Followers[0];

            Assert.AreEqual("Alan", alan.Name);
            Assert.AreEqual("Martin", martin.Name);
            Assert.AreEqual("Ward", wardFollowingAlan.Name);
            Assert.AreEqual("Ward", wardFollowingMartin.Name);

        }
    }
}
