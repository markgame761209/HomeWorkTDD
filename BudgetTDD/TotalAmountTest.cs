using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetTDD
{
    [TestClass]
    public class TotalAmountTest
    {
        private IRepository<Budget> _repository = Substitute.For<IRepository<Budget>>();
        private Accounting _accounting;

        [TestInitialize]
        public void TestInit()
        {
            _accounting = new Accounting(_repository);
        }

        private void TotalAmountShouldBe(int expected, DateTime staDateTime, DateTime endDateTime)
        {
            Assert.AreEqual(expected, _accounting.TotalAmount(staDateTime, endDateTime));
        }

        [TestMethod]
        public void no_budgets()
        {
            GivenBudgets();

            TotalAmountShouldBe(0, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        [TestMethod]
        public void no_effiective_one_effective_day_period_inside_budget_month()
        {
            GivenBudgets(new Budget{YearMonth = "201804" , Amount = 30});

            TotalAmountShouldBe(1, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        private void GivenBudgets(params Budget[] Budgets)
        {
            _repository.GetAll().Returns(Budgets.ToList());
        }
    }
}