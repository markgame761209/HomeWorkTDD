using System.Collections.Generic;

namespace BudgetTDD
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}