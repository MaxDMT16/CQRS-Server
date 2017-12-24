using System;
using System.Collections.Generic;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Queries.Category
{
    public class CategoriesResponse : IQueryResult
    {
        public ICollection<Category> Categories { get; set; }

        public class Category
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Area { get; set; }
        }
    }
}