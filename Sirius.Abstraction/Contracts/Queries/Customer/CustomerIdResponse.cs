using System;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Queries.Customer
{
    public class CustomerIdResponse : IQueryResult
    {
        public Guid Id { get; set; }
    }
}