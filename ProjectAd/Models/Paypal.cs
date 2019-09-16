using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAd.Models
{
    public class PDTHolder
    {
        public double TotalPrice { get; set; }
        public ApplicationUser User { get; set; }
        public Ad userAd { get; set; }
        public static string authToken, txToken, query, strResponse;

        public static PDTHolder Success(string tx)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //authToken = WebConfigurationManager.AppSettings["PDTToken"];
            //txToken = tx;
            //query = string.Format("cmd=_notify-synch&tx={0}&at={1}", txToken, authToken);
            //string url = WebConfigurationManager.AppSettings["PaypalSubmitUrl"];
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.Method = "POST";
            //req.ContentType = "application/x-www-form-urlencoded";
            //req.ContentLength = query.Length;
            //StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            //stOut.Write(query);
            //stOut.Close();
            //StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            //strResponse = stIn.ReadToEnd();
            //stIn.Close();
            //if (strResponse.StartsWith("SUCCESS"))
            //{
            //    return PDTHolder.Parse(strResponse);
            //}
                
            return null;


        }
    }

    


}
