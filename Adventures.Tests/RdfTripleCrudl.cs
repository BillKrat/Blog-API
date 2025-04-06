// Adventures.Tests > RdfTripleCrudl.cs
/* ================================================================================
 * Copyright (c) 2025 Bill Kratochvil / email: bill@adventuresOnTheEdge.net
 * =================================================================================
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the conditions of the MIT license [see LICENSE
 * in the Solution artificats folder of which the above is an exceprt].
 * =================================================================================
 * Updated      Modified by     Rationale for update
 * ----------   --------------  ----------------------------------------------------
 * 2025.04.05   BillKrat        Created file     
 * 
*/
using Adventures.Business.BusinessComponent;
using Adventures.Data.DataAccessComponent;
using Adventures.Data.Interfaces;
using Adventures.Framework.Extensions;
using Adventures.Framework.Interfaces;
using Adventures.Model.DataSource;
using Adventures.Model.Events;
using Adventures.Model.Extensions;
using Adventures.Model.Results;
using Adventures.Model.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace Adventures.Tests
{
    [TestClass]
    public sealed class RdfTripleCrudl
    {
        #region attributed
        //[ClassInitialize]
        //public static void ClassInit(TestContext context)
        //{
        //    // This method is called once for the test class, before any tests of the class are run.
        //}

        //[ClassCleanup]
        //public static void ClassCleanup()
        //{
        //    // This method is called once for the test class, after all tests of the class are run.
        //}

        //[TestInitialize]
        //public void TestInit()
        //{
        //    // This method is called before each test method.
        //}

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    // This method is called after each test method.
        //}
        #endregion

        [TestMethod]
        public void CanListTriples()
        {
            // Register services with the container
            var services = new ServiceCollection();
            services.AddTransient<TestFacade>();
            services.AddTransient<ICrudlBL, CrudlBL>();
            services.AddTransient<ICrudlDL, CrudlDL>();

            services.AddDbContext<ITripleStoreContext, TripleStoreContext>();

            var serviceProvider = services.BuildServiceProvider();

            // Request our business logic class and request data. The data layer
            // will provide a generic CrudlResult and the business layer a more
            // specific RdfTripeResult so we'll down case
            var facade = serviceProvider.GetService<TestFacade>();
            var result = facade?.GetSimpleMockData();
            
            // Assert unit test data
            var one = result?.Data?
                .FirstOrDefault(r => r.Id == TestFacade.SimpleOneId);
            Assert.AreEqual("one", one?.Object);
            Assert.AreEqual("tag1", one?.Tag.GetString());
            Assert.IsNotNull(result);

            var two = result?.Data?
                .FirstOrDefault(r => r.Id == TestFacade.SimpleTwoId);
            Assert.AreEqual("two", two?.Object);
            Assert.AreEqual("tag2", two?.Tag.GetString());
            Assert.IsNotNull(result);

            var three = result?.Data?
                .FirstOrDefault(r => r.Id == TestFacade.SimpleThreeId);
            Assert.AreEqual("three", three?.Object);
            Assert.AreEqual("tag3", three?.Tag.GetString());
            Assert.IsNotNull(result);

        }
    }
}
