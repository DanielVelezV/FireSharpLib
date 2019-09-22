using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseAPI
{
    public static class FireProcessor
    {
        /// <summary>
        /// Obtains the data from the [path].
        /// </summary>
        /// <typeparam name="T">Data convertion type. [From JSON to T]</typeparam>
        /// <param name="path">Path where the data is. IE: https://csharpdataaccess.firebaseio.com/[Path]</param>
        /// <returns>The data from Json to T. Nothing if the path is null or misspelled</returns>
        public static async Task<T> GetData<T>(string path)
        {
            using (HttpResponseMessage resp = await FireClient.client.GetAsync(FireClient.client.BaseAddress + path + ".json"))
            {
                if (resp.IsSuccessStatusCode)
                {
                    T data =  await resp.Content.ReadAsAsync<T>();
                    if (data!=null)
                    {
                        return data;
                    }
                    else
                    {
                        Console.Write("Error getting the data. Information:");
                        return default;
                    }
                }
                return default;

            }
        }

        /// <summary>
        /// Same as GetData() but with the Auth Token.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<T> GetDataAuth<T>(string path)
        {
            using (HttpResponseMessage resp = await FireClient.client.GetAsync(FireClient.client.BaseAddress + path + ".json?auth=" + FireClient.Token))
            {
                if (resp.IsSuccessStatusCode)
                {
                    T data = await resp.Content.ReadAsAsync<T>();
                    if (data != null)
                    {
                        return data;
                    }
                    else
                    {
                        Console.WriteLine("Error getting the data. Information:");
                        return default;
                    }
                }
                return default;

            }
        }

        /// <summary>
        /// Insert the data [T] in Json format to the [path]. 
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="path">Path where the data will be stored</param>
        /// <param name="data">Data that will be stored</param>
        /// <returns>True if the data was inserted correctly, false if not</returns>
        public static async Task<bool> SetData<T>(string path, T data)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, FireClient.client.BaseAddress + path + ".json"))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data));

                var response = await FireClient.client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Same as SetData() but with Auth Token.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<bool> SetDataAuth<T>(string path, T data)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, FireClient.client.BaseAddress + path + ".json?auth" + FireClient.Token))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data));

                var response = await FireClient.client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Deletes the data from the [path]
        /// </summary>
        /// <param name="path">Path where the data will be deleted</param>
        /// <returns>True if the data was removed correctly, false if not</returns>     
        public static async Task<bool> DeleteData(string path)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, FireClient.client.BaseAddress + path + ".json"))
            {
                var response = await FireClient.client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Same as DeleteData() but with Auth Token.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task DeleteDataAuth(string path)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, FireClient.client.BaseAddress + path + ".json?auth=" + FireClient.Token))
            {
                await FireClient.client.SendAsync(request);
            }
        }
    }
}
