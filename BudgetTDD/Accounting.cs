using System;
using System.Linq;

namespace BudgetTDD
{
    internal class Accounting
    {
        private IRepository<Budget> _repository;

        public Accounting(IRepository<Budget> repository)
        {
            this._repository = repository;
        }

        public decimal TotalAmount(DateTime staDateTime, DateTime endDateTime)
        {
            var budgets = _repository.GetAll();
            if (budgets.Any())
            {
                var days = (endDateTime.AddDays(1) - staDateTime).Days;
                return days;
            }
            return 0;
        }
    }
}