using System;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    public interface IGreenhouseUser
    {
        int ID { get; set; }
        Guid UserID { get; set; }
        string Username { get; set; }
        int GreenhouseID { get; set; }
        Greenhouse Greenhouse { get; set; }
        int Save();
        int Save(DataContext dc);
        void Delete(DataContext dc);
        void Delete();
    }
}