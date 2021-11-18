using Newtonsoft.Json;
using OneSevenTest.Modal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public void GetItems()
        {
            var url = $"https://fakestoreapi.com/products/1";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            string json = JsonConvert.SerializeObject(responseBody);
                            Product test = JsonConvert.DeserializeObject<Product>(json);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
