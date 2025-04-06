// Adventures.Model > Tests > TestFacade.cs
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
using Adventures.Framework.Interfaces;
using Adventures.Model.Events;
using Adventures.Model.Extensions;
using Adventures.Model.Results;

namespace Adventures.Model.Tests
{
    public class TestFacade(ICrudlBL crudlBl)
    {
        public const string SimplePredicate = "[schema]mockdata/basic/0.1/simple";
        public const string SimpleOneId = "efe2b16-106a-cdc5-fff63766ced031e41";
        public const string SimpleTwoId = "879817c-f2d6-5534-5c1318ae5e5413032";
        public const string SimpleThreeId = "2e92239-df06-28e3-7a33efc8b56077ad5";

        public const string WeatherPredicate = 
            "[schema]mockdata/weather/0.1/summaries";
        public const string WeatherCategories = 
            "Freezing, Bracing, Chilly, Cool, Mild, Warm, Balmy, " +
            "Hot, Sweltering, Scorching";

        /// <summary>
        /// Mock data for simple unit test
        /// </summary>
        /// <example> CSV data of mock unit test data follows
        /// Id,Subject,Predicate,Object,Tag
        /// efe2b16-106a-cdc5-fff63766ced031e41,[schema]#unittest,[schema]mockdata/basic/0.1/simple,one,tag1
        /// 879817c-f2d6-5534-5c1318ae5e5413032,[schema]#unittest,[schema]mockdata/basic/0.1/simple,two,tag2
        /// 2e92239-df06-28e3-7a33efc8b56077ad5,[schema]#unittest,[schema]mockdata/basic/0.1/simple,three,tag3
        /// 6d6fd4c-fb31-3c4d-30b48d93823eaea4e,[schema]#unittest,"[schema]mockdata/weather/0.1/summaries
        /// ","""Freezing"", ""Bracing"", ""Chilly"", ""Cool"", ""Mild"", ""Warm"", 
        /// ""Balmy"", ""Hot"", ""Sweltering"", ""Scorching""",
        /// </example>
        /// <returns>Data from Sqlite DataSource/TripleStore.db  </returns>
        public RdfTripleResults? GetSimpleMockData()
        {
            var queryArgs = new 
                RdfCrudlEventArgs("[schema]#unittest", SimplePredicate);

            RdfTripleResults? result = crudlBl?
                .GetData(this, queryArgs).DownCast();
            
            return result;
        }
    }
}
