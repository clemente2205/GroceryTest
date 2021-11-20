using Newtonsoft.Json;
using OneSevenTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace OneSevenTest.Helper
{
    internal class ApiHelper
    {

        #region Singleton

        private ApiHelper() { }
        private static ApiHelper instance = null;
        public static ApiHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiHelper();
                }
                return instance;
            }
        }

        #endregion Singleton

        #region Methods

        /// <summary>
        /// method for get dummy products 
        /// </summary>
        public List<TblProduct> GetNewItemsApi()
        {
            var url = $"https://fakestoreapi.com/products";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            List<TblProduct> products = new List<TblProduct>();
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return products;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            string json = JsonConvert.SerializeObject(responseBody);
                            var cleanJson = JsonConvert.DeserializeObject<dynamic>(json);
                            products = JsonConvert.DeserializeObject<IList<TblProduct>>(cleanJson);
                        }
                    }
                }
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods
    }
}
