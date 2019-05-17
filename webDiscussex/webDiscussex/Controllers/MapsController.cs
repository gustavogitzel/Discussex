using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net;
using System.IO;
using System.Net.Http;

namespace webDiscussex.Controllers
{
    
    [EnableCors(origins: "http://localhost:61322", headers: "*", methods: "*")]
    public class MapsController : ApiController
    {
        // GET: Maps
        //public String Get()
        //{
        //    WebRequest request = WebRequest.Create(
        //    "https://maps.googleapis.com/maps/api/place/textsearch/xml?query==posto+de+saude+near+Jardim Campos Eliseos&rankyby=distance&radius=10000&key=AIzaSyBBh6JK23HFsrPff9iyGpdfzztePcfRhq4");
        //    request.Credentials = CredentialCache.DefaultCredentials;

        //    WebResponse response = request.GetResponse();

        //    using (Stream dataStream = response.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(dataStream);
        //        string responseFromServer = reader.ReadToEnd();
        //        response.Close();
        //        return (responseFromServer);
        //    }
        //}
        
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test message")
            };

        }
    }
}