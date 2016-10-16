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

            var user = userList[0];
            var following = user.Following[0];

            Assert.AreEqual(2, userList.Count);
            Assert.AreEqual("Ward", user.Name);
            Assert.AreEqual("Alan", following.Name);
            Assert.AreEqual(0, following.Following.Count);
        }

        [TestMethod]
        public void Create_WithThreeUsersExistsWithOneUserFollowingTwoUsers_ReturnsThreeUsersTwoBeingOneFollowedOneWithNoFollowers()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["TwoFollowerPath"]);
            var userList = UserBuilder.Create(users);

            var ward = userList[0];
            var martin = userList[1];
            var alan = userList[2];

            var alanFollowingCount = alan.Following.Count;
            var martingFollowingCount = martin.Following.Count;
            var wardFollowingCount = ward.Following.Count;

            Assert.AreEqual(3, userList.Count);            
            Assert.AreEqual(0, alanFollowingCount);
            Assert.AreEqual(0, martingFollowingCount);
            Assert.AreEqual(2, wardFollowingCount);

        }
    }
}
