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
        public void Create_WhereInputHasThreeUniqueUsers_ReturnsThreeUsers()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["UserFilePath"]);
            var usersList = UserBuilder.Create(users);

            Assert.AreEqual(3, usersList.Count);
        }

        [TestMethod]
        public void Create_WhereTwoUsersExists_ReturnsTwoUserOneAsAFollower()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["OneFollowerPath"]);
            var userList = UserBuilder.Create(users);

            var user = userList[1];
            var follower = user.Followers[0];

            Assert.AreEqual(2, userList.Count);
            Assert.AreEqual("Ward", follower.Name);
            Assert.AreEqual("Alan", user.Name);

        }

        [TestMethod]
        public void Create_WithThreeUsersExistsWithOneUserFollowingTwoUsers_ReturnsThreeUsersTwoBeingOneFollowedOneWithNoFollowers()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["TwoFollowerPath"]);
            var userList = UserBuilder.Create(users);

            var ward = userList[0];
            var alan = userList[2];
            var martin = userList[1];
            var wardFollowingAlan = alan.Followers[0];
            var wardFollowingMartin = martin.Followers[0];

            Assert.AreEqual(3, userList.Count);
            Assert.AreEqual("Alan", alan.Name);
            Assert.AreEqual("Martin", martin.Name);
            Assert.AreEqual("Ward", wardFollowingAlan.Name);
            Assert.AreEqual("Ward", wardFollowingMartin.Name);
            Assert.AreEqual(0, ward.Followers.Count);

        }
    }
}
