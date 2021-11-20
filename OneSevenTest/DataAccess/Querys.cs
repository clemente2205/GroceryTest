using Microsoft.EntityFrameworkCore;
using OneSevenTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OneSevenTest.DataAccess
{
    public class Querys
    {
        #region Singleton

        private Querys() { }
        private static Querys instance = null;
        public static Querys Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Querys();
                }
                return instance;
            }
        }

        #endregion Singleton

        #region Methods

        public void SaveNewItems(List<TblProduct> products)
        {
            try
            {
                using (var contex = new masterContext())
                {
                    foreach (TblProduct item in products)
                    {
                        contex.Entry(item).State = EntityState.Added;
                        contex.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //cleaning the database everytime call products from appi
        public void CleanTable()
        {
            try
            {
                using (var contex = new masterContext())
                {
                    //TODO: use sp
                    contex.Database.ExecuteSqlRaw("delete from tblProducts");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TblProduct> GetTable()
        {
            List<TblProduct> products = new List<TblProduct>();
            try
            {
                using (var contex = new masterContext())
                {
                    products = contex.TblProducts.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return products;
        }

        #endregion Methods
    }
}
