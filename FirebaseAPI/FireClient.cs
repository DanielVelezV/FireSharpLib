using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseAPI
{
    static public class FireClient
    {
        public static HttpClient client = new HttpClient();
        /// <summary>
        /// Private Token used for the [Auth] methods. 
        /// Found in https://console.firebase.google.com/u/0/project/[PROJECT_ID]/settings/serviceaccounts/databasesecrets
        /// </summary>
        public static string Token { get; set; }
        /// <summary>
        /// Initialize the HTTP Client 
        /// </summary>
        /// <param name="baseAddress">Base Address, IE: https://[PROJECT.ID].firebaseio.com/</param>
        public static void InitializeClient(string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
