// Adventures.Model > Extensions > CastExtensions.cs
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
using Adventures.Framework.Events;
using Adventures.Framework.Results;
using Adventures.Model.Events;
using Adventures.Model.Results;

namespace Adventures.Model.Extensions
{
    public static class CastExtensions
    {
        public static RdfTripleResults? DownCast(this CrudlResult? results)
        {
            return (RdfTripleResults?)results;
        }
        public static RdfCrudlEventArgs? DownCast(this CrudlEventArgs? results)
        {
            return (RdfCrudlEventArgs?)results;
        }

    }
}
