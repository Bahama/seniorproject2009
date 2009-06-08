using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class GreenhouseFilters
    {
        public static IList<Greenhouse> All(this IQueryable<Greenhouse> qry)
        {
            return qry.ToList();
        }

        public static Greenhouse ByID(this IQueryable<Greenhouse> qry, int id)
        {
            return (qry.Where(x => x.ID == id)).SingleOrDefault();
        }

        public static IQueryable<Greenhouse> ByUser(this IQueryable<Greenhouse> qry, string username)
        {
            return qry.Where(x => x.Usernames.Contains(username));
        }
    }
}