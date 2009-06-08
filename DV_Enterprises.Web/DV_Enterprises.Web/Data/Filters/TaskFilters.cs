using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class TaskFilters
    {
        public static IList<Task> All(this IQueryable<Task> qry)
        {
            return qry.ToList();
        }

        public static Task ByID(this IQueryable<Task> qry, int id)
        {
            return (qry.Where(x => x.ID == id)).SingleOrDefault();
        }
    }
}