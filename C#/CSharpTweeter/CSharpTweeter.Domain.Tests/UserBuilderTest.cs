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

            Assert.AreEqual(2, usersList.Count);
        }

        [TestMethod]
        public void Create_WhereOneFollowerExists_ReturnsUserWithOneFollower()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["UserFilePath"]);
            var userList = UserBuilder.Create(users);

            var user = userList[0];
            var follower = user.Followers[0];

            Assert.AreEqual("Ward", user.Name);
            Assert.AreEqual("Alan", follower.Name);

        }

        [TestMethod]
        public void Create_WhereTwoFollowerExists_ReturnsUserWithTwoFollowers()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["TwoFollowerPath"]);
            var userList = UserBuilder.Create(users);

            var user = userList[0];
            var follower1 = user.Followers[0];
            var follower2 = user.Followers[1];

            Assert.AreEqual("Ward", user.Name);
            Assert.AreEqual("Martin", follower1.Name);
            Assert.AreEqual("Alan", follower2.Name);

        }
    }
}
