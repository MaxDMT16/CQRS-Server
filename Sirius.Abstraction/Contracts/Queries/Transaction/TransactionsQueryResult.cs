using System;
using System.Collections.Generic;
using Sirius.Abstraction.CQRS;

namespace Sirius.Abstraction.Contracts.Queries.Transaction
{
    public class TransactionsQueryResult : IQueryResult
    {
        public ICollection<Transaction> Transactions { get; set; }

        public class Transaction
        {
            public string Status { get; set; }
            public Guid OrderId { get; set; }
        }
    }
}