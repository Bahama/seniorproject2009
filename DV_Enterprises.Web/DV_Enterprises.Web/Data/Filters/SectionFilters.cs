using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class SectionFilters
    {
        public static IList<Section> All(this IQueryable<Section> qry)
        {
            return qry.ToList();
        }

        public static Section ByID(this IQueryable<Section> qry, int id)
        {
            return (qry.Where(x => x.ID == id)).SingleOrDefault();
        }
    }
}