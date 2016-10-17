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

        /// <summary>
        /// <file>
        ///  <key>UserFilePath</key>
        ///  <text>         
        ///  Ward follows Alan
        ///  Alan follows Martin
        ///  Ward follows Martin, Alan
        /// </text>
        /// </file>
        /// </summary>
        [TestMethod]
        public void Create_WhereInputHasThreeUniqueUsers_ReturnsThreeUsers()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["UserFilePath"]);
            var usersList = UserBuilder.Create(users);

            Assert.AreEqual(3, usersList.Count);
        }

        /// <summary>
        /// <file>
        ///  <key>OneFollowerPath</key>
        ///  <text>         
        ///  Ward follows Alan
        /// </text>
        /// </file>
        /// </summary>
        [TestMethod]        
        public void Create_WhereTwoUsersExists_ReturnsTwoUserOneAsAFollower()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["OneFollowerPath"]);
            var userList = UserBuilder.Create(users);

            var ward = userList[0];
            var alan = userList[1];

            Assert.AreEqual(2, userList.Count);
            Assert.AreEqual(1, ward.Following.Count);
            Assert.AreEqual(0, alan.Following.Count);
        }

        /// <summary>
        /// <file>
        ///  <key>TwoFollowerPath</key>
        ///  <text>         
        ///  Ward follows Martin, Alan
        /// </text>
        /// </file>
        /// </summary>        
        [TestMethod]        
        public void Create_WithThreeUsersExistsWithOneUserFollowingTwoUsers_ReturnsThreeUsersTwoBeingOneFollowedOneWithNoFollowers()
        {
            string users = GetUsersFromFile(ConfigurationManager.AppSettings["TwoFollowerPath"]);
            var userList = UserBuilder.Create(users);

            var ward = userList[0];
            var martin = userList[1];
            var alan = userList[2];

            Assert.AreEqual(3, userList.Count);
            Assert.AreEqual(0, alan.Following.Count);
            Assert.AreEqual(0, martin.Following.Count);
            Assert.AreEqual(2, ward.Following.Count);

        }
    }
}
