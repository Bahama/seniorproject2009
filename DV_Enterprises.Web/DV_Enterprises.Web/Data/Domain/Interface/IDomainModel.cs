using DV_Enterprises.Web.Data.DataAccess.SqlRepository;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    /// <summary>
    /// This inteface defines the methods that all Domain models should share
    /// </summary>
    public interface IDomainModel
    {
        #region Static properties

        #endregion

        #region Instance properties

        int ID { get; set; }

        #endregion

        # region Static Methods

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save IDomainModel
        /// </summary>
        /// <returns>returns the id of the saved model</returns>
        int Save();

        /// <summary>
        /// Save IDomainModel
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>returns the id of the saved model</returns>
        int Save(DataContext dc);

        /// <summary>
        /// Delete IDomainModel
        /// </summary>
        void Delete();

        /// <summary>
        /// Delete IDomainModel
        /// </summary>
        /// <param name="dc"></param>
        void Delete(DataContext dc);

        #endregion
    }
}