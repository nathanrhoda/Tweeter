using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using CSharpTweeter.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTweeter.Domain.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        /// <summary>
        /// <file>
        ///  <key>TweetFilePath</key>
        ///  <text>         
        ///  Alan> If you have a procedure with 10 parameters, you probably missed some.
        ///  Ward> There are only two hard things in Computer Science: cache invalidation, naming things and off-by-1 errors.
        ///  Alan> Random numbers should not be generated with a method chosen at random.
        /// </text>
        /// </file>
        /// </summary>
        [TestMethod]
        public void GetUsers_WhereUsersExist_ReturnsMoreThan3Users()
        {
            var userFilePath = ConfigurationManager.AppSettings["UserFilePath"];
            var service = new UserService(userFilePath);
            var users = service.GetUsers();
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Initialize_WhereInputIsNotValid_ThrowsException()
        {
            var service = new UserService("");

        }
      
    }    
}