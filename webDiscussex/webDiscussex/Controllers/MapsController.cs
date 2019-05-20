using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Xml;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace webDiscussex.Controllers
{
    
    [EnableCors(origins: "http://localhost:61322", headers: "*", methods: "*")]
    public class MapsController : ApiController
    {
        // GET: Maps
        public string Get(string id)
        {
            id.Replace(" ", "%20");
            WebRequest request = WebRequest.Create(
            "https://maps.googleapis.com/maps/api/place/textsearch/xml?query==posto+de+saude+near+"+id+"&rankyby=distance&radius=10000&key=AIzaSyBBh6JK23HFsrPff9iyGpdfzztePcfRhq4");
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                
                response.Close();

                return responseFromServer;
            }
        }
    }
}