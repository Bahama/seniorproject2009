using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Abstract;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Section : DomainModel, ISection
    {
        #region Static properties

        private static readonly Repository.Section Repository = new Repository.Section();

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string Name { get; set; }
        public int GreenhouseID { get; set; }
        public int PresetID { get; set; }
        public Guid UserID { get; set; }
        public bool IsTemperatureActivated { get; set; }
        public int? IdealTemperature { get; set; }
        public int? TemperatureThreshold { get; set; }
        public bool IsLightActivated { get; set; }
        public int? IdealLightIntensity { get; set; }
        public int? LightIntensityThreshold { get; set; }
        public bool IsHumidityActivated { get; set; }
        public int? IdealHumidity { get; set; }
        public int? HumidityThreshold { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Section's
        /// </summary>
        /// <returns>return an IQueryable collection of Section</returns>
        public static IQueryable<Section> All()
        {
            return All(null);
        }

        /// <summary>
        /// Find all Section's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Section</returns>
        public static IQueryable<Section> All(DataContext dc)
        {
            return Repository.All(dc);
        }

        /// <summary>
        /// Find an Section by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a Section</returns>
        public static Section Find(int id)
        {
            return Find(null, id);
        }

        /// <summary>
        /// Find an Section by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Section</returns>
        public static Section Find(DataContext dc, int id)
        {
            return Repository.Find(dc, id);
        }

        /// <summary>
        /// Save a Section
        /// </summary>
        /// <param name="section"></param>
        /// <returns>returns the id of the saved section</returns>
        public static int Save(Section section)
        {
            return Save(null, section);
        }

        /// <summary>
        /// Save a Section
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="section"></param>
        /// <returns>returns the id of the saved section</returns>
        public static int Save(DataContext dc, Section section)
        {
            return Repository.Save(dc, section);
        }

        /// <summary>
        /// Delete a single 
        /// </summary>
        /// <param name="section"></param>
        public static void Delete(Section section)
        {
            Delete(null, section);
        }

        /// <summary>
        /// Delete a single 
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="section"></param>
        public static void Delete(DataContext dc, Section section)
        {
            Repository.Delete(dc,section);
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Section
        /// </summary>
        /// <returns>returns the id of the saved section</returns>
        public int Save()
        {
            return Save(this);
        }
        
        /// <summary>
        /// Save Section
        /// </summary>
        /// <returns>returns the id of the saved section</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }

        /// <summary>
        /// Delete Section
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Section
        /// </summary>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion
    }
}