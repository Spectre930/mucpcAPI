using FilteringandPagination;
using System.Linq.Expressions;


namespace FilteringandPagination;
public static class CustomExpressionSort<T> where T : class
{
    public class ExpressionSort
    {
        public string ColumnName { get; set; }
        public bool Descending { get; set; }
    }

    public static IOrderedQueryable<T> CustomSort(List<ColumnSorting> columnSortings, IQueryable<T> query)
    {
        var expressionSorts = new List<ExpressionSort>();
        foreach (var item in columnSortings)
        {
            expressionSorts.Add(new ExpressionSort() { ColumnName = item.id, Descending = item.desc });
        }

        IOrderedQueryable<T> orderedQuery = null;

        for (int i = 0; i < expressionSorts.Count; i++)
        {
            var sortOption = expressionSorts[i];
            var param = Expression.Parameter(typeof(T), "x");
            var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, sortOption.ColumnName), typeof(object)), param);

            if (i == 0)
            {
                orderedQuery = sortOption.Descending ? query.OrderByDescending(sortExpression) : query.OrderBy(sortExpression);
            }
            else
            {
                orderedQuery = sortOption.Descending ? orderedQuery.ThenByDescending(sortExpression) : orderedQuery.ThenBy(sortExpression);
            }
        }

        return orderedQuery ?? query.OrderBy(x => 0); // If no sorting is applied, return the original query
    }
}