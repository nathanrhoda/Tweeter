using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class UserBuilderTest
    {

        private string GetUsersFromFile()
        {
            var userFilePath = ConfigurationManager.AppSettings["UserFilePath"];
            var fileText = File.ReadAllText(userFilePath);
            return fileText;
        }


        [TestMethod]
        public void UserBuilder_WhereStringWithTwoUniqueUsersSupplied_ReturnsTwoUsers()
        {
            string users = GetUsersFromFile();
            var usersList = UserBuilder.Create(users);

            Assert.AreEqual(2, usersList.Count);
        }
    }
}
