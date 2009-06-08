using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class GreenhouseUserFilters
    {
        public static IList<GreenhouseUser> All(this IQueryable<GreenhouseUser> qry)
        {
            return qry.ToList();
        }

        public static IQueryable<GreenhouseUser> ByID(this IQueryable<GreenhouseUser> qry, int greenhouseUserID)
        {
            return qry.Where(x => x.ID == greenhouseUserID);
        }

        public static IQueryable<GreenhouseUser> ByGreenhouseID(this IQueryable<GreenhouseUser> qry, int greenhouseID)
        {
            return qry.Where(x => x.GreenhouseID == greenhouseID);
        }

        public static IQueryable<GreenhouseUser> ByUser(this IQueryable<GreenhouseUser> qry, string username)
        {
            return qry.Where(x => x.Username.ToLower() == username.ToLower());
        }
    }
}