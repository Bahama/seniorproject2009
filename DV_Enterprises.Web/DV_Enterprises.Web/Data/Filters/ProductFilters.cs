using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class ProductFilters
    {
        public static IList<Product> All(this IQueryable<Product> qry)
        {
            return qry.ToList();
        }

        public static Product ByID(this IQueryable<Product> qry, int id)
        {
            return (qry.Where(x => x.ID == id)).SingleOrDefault();
        }
    }
}