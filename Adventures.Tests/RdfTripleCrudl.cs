using Adventures.Business.BusinessComponent;
using Adventures.Data.DataAccessComponent;
using Adventures.Data.Interfaces;
using Adventures.Framework.Events;
using Adventures.Framework.Interfaces;
using Adventures.Model.DataSource;
using Adventures.Model.Extensions;
using Adventures.Model.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Adventures.Tests
{
    [TestClass]
    public sealed class RdfTripleCrudl
    {
        #region attributed
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // This method is called once for the test class, before any tests of the class are run.
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // This method is called once for the test class, after all tests of the class are run.
        }

        [TestInitialize]
        public void TestInit()
        {
            // This method is called before each test method.
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // This method is called after each test method.
        }
        #endregion

        [TestMethod]
        public void CanListTriples()
        {
            // Register services with the container
            var services = new ServiceCollection();
            services.AddTransient<ICrudlBL, CrudlBL>();
            services.AddTransient<ICrudlDL, CrudlDL>();
            services.AddDbContext<ITripleStoreContext, TripleStoreContext>();
            var serviceProvider = services.BuildServiceProvider();

            // Request our business logic class and request data. The data layer
            // will provide a generic CrudlResult and the business layer a more
            // specific RdfTripeResult so we'll down case
            var crudlBl = serviceProvider.GetService<ICrudlBL>();
            RdfTripleResults? result = crudlBl?
                .GetData(this, new CrudlEventArgs()).DownCast();
            
            // Assert unit test data
            var one = result?.Data?.FirstOrDefault(r => r.Id == "one");
            Assert.AreEqual("three", one?.Object);
            Assert.AreEqual("two", one?.Predicate);
            Assert.IsNotNull(result);

            var two = result?.Data?.FirstOrDefault(r => r.Id == "two");
            Assert.AreEqual("five", two?.Object);
            Assert.AreEqual("four", two?.Predicate);
            Assert.IsNotNull(result);

            var three = result?.Data?.FirstOrDefault(r => r.Id == "three");
            Assert.AreEqual("six", three?.Object);
            Assert.AreEqual("five", three?.Predicate);
            Assert.IsNotNull(result);

        }
    }
}
