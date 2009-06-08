using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class PresetFilters
    {
        public static IList<Preset> All(this IQueryable<Preset> qry)
        {
            return qry.ToList();
        }

        public static Preset ByID(this IQueryable<Preset> qry, int id)
        {
            return (qry.Where(x => x.ID == id)).SingleOrDefault();
        }
    }
}