using GoStyle.Models;
using GoStyle.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace TestGoStyle
{
    /// <summary>
    /// Description résumée pour UnitTestReductionServices
    /// </summary>
    [TestClass]
    public class UnitTestReductionServices
    {
        public UnitTestReductionServices()
        {
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

        [TestCleanup()]
        public void MyTestCleanup() 
        {
            UserService.getInstance().Logout();
        }

        #endregion
        [TestMethod]
        public void GetInstance()
        {
            bool ez = UserService.getInstance().Connexion("t_t", "t");

            ReductionServices reductionServices = ReductionServices.GetInstance();
            Assert.IsInstanceOfType(reductionServices, typeof(ReductionServices));
        }

        [TestMethod]
        public void GetReductionAsync()
        {
            Task<Reduction> reduction = ReductionServices.GetInstance().GetReductionAsync("6317bc4b-f183-4b60-b098-f5f2c95e5df5");
            Assert.IsNotNull(reduction);
        }

        /// <summary>
        /// Méthode de test de pour l'obtention des réductions scannée par l'utilisateur
        /// </summary>
        [TestMethod]
        public void GetReductions()
        {
            ObservableCollection<Reduction> reductions = ReductionServices.GetInstance().GetReductions();
            Assert.IsInstanceOfType(reductions, typeof(ObservableCollection<Reduction>));
        }
    }
}
