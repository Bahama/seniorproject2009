using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository.Interface
{
    [PluginFamily("Default")]
    public interface IGreenhouseUserRepository
    {
        #region Static properties

        #endregion

        #region Instance properties

        Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        IQueryable<Domain.GreenhouseUser> Find(DataContext dc);
        int Save(DataContext dc, Domain.GreenhouseUser model);
        void Delete(DataContext dc, Domain.GreenhouseUser model);

        #endregion
    }
}