using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace ANDDigitalTest.BuisinessLayer
{
    public class DataAccessHelper
    {
        
        internal async System.Threading.Tasks.Task<string> GetJsonStringAsync()
        {
            try
            {
                //Read mock data from json

                string path = System.Web.Hosting.HostingEnvironment.MapPath("~/MockData/Customers.json");
                if (string.IsNullOrEmpty(path))
                    path = Path.GetFullPath(@"MockData\Customers.json");


                // String path =Path.GetFullPath(@"MockData\Customers.json");
                using (FileStream fileStream = new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                //Log Excetion  and return null
                return null;
            }
           
        }
        internal async System.Threading.Tasks.Task<bool> SaveJsonStringAsync(string jsonString)
        {
            try
            {
                //Read mock data from json
                string path = System.Web.Hosting.HostingEnvironment.MapPath("~/MockData/Customers.json");
                if (string.IsNullOrEmpty(path))
                    path = Path.GetFullPath(@"MockData\Customers.json");

                Mutex mutex = new Mutex(false,Path.GetFileNameWithoutExtension(path));
                // String path =Path.GetFullPath(@"MockData\Customers.json");
                if(mutex.WaitOne(3000))
                {
                    //Catch any exception to avoid deadlocks
                    try
                    {
                        using (FileStream fileStream = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.Read))
                        {
                            using (StreamWriter writer = new StreamWriter(fileStream))
                            {
                                 await writer.WriteAsync(jsonString);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        //Log exception and return false
                        return false;
                    }
                    mutex.ReleaseMutex();
                }
                else
                {
                    //Lock is still in usee
                    return false;
                }
              
            }
            catch (Exception ex)
            {
                //Log Excetion  and return false
                return false;
            }
            return true;
        }

    }
}