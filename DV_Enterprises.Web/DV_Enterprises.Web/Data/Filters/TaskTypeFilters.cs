using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class TaskTypeFilters
    {
        public static IList<TaskType> All(this IQueryable<TaskType> qry)
        {
            return qry.ToList();
        }

        public static TaskType ByID(this IQueryable<TaskType> qry, int id)
        {
            return (qry.Where(x => x.ID == id)).SingleOrDefault();
        }

        public static TaskType ByType(this IQueryable<TaskType> qry, TaskTypes type)
        {
            var r = qry.Where(x => x.Name == type.ToString()).SingleOrDefault();
            if( r == null)
            {
                r = new TaskType
                        {
                            Name = type.ToString(),
                            Type = type
                        };
                r.Save();
            }
            return r;
        }
    }
}