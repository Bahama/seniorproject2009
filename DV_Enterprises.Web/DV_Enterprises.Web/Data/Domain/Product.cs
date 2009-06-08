using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Product : IProduct
    {
        #region Static properties

        private static readonly Repository.ProductRepository Repository = new Repository.ProductRepository();

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Product's
        /// </summary>
        /// <returns>return an IQueryable collection of Product</returns>
        public static IQueryable<Product> Find()
        {
            return Find(null);
        }

        /// <summary>
        /// Find all Product's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Product</returns>
        public static IQueryable<Product> Find(DataContext dc)
        {
            return Repository.Find(dc);
        }

        /// <summary>
        /// Save a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>returns the id of the saved product</returns>
        public static int Save(Product product)
        {
            return Save(null, product);
        }

        /// <summary>
        /// Save a Product
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="product"></param>
        /// <returns>returns the id of the saved product</returns>
        public static int Save(DataContext dc, Product product)
        {
            return Repository.Save(dc, product);
        }

        /// <summary>
        /// Delete a single product
        /// </summary>
        /// <param name="product"></param>
        public static void Delete(Product product)
        {
            Delete(null, product);
        }

        /// <summary>
        /// Delete a single product
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="product"></param>
        public static void Delete(DataContext dc, Product product)
        {
            Repository.Delete(dc, product);
        }


        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Product
        /// </summary>
        /// <returns>returns the id of the saved product</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Save Product
        /// </summary>
        /// <returns>returns the id of the saved product</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion
    }
}