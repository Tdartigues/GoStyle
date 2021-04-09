using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GoStyle.Services;
using GoStyle.Models;

namespace TestGoStyle
{
    /// <summary>
    /// Description résumée pour UnitTestUserServices
    /// </summary>
    [TestClass]
    public class UnitTestUserServices
    {
        UserService userService;
        public UnitTestUserServices()
        {
            userService = UserService.getInstance();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetInstance()
        {
            UserService test = UserService.getInstance();
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void TestGetUserOutCo()
        {
            User test = UserService.getInstance().getUser();
            Assert.IsNull(test);
        }

        [TestMethod]
        public void TestConnexion()
        {
            bool test = UserService.getInstance().Connexion("t_t","t");
            Assert.IsTrue(test);
        }

        public void TestGetUserInCo()
        {
            User test = UserService.getInstance().getUser();
            Assert.IsNotNull(test);
        }

        public void TestLogout()
        {
            bool test = UserService.getInstance().Logout();
            Assert.IsTrue(test);
        }
    }
}
