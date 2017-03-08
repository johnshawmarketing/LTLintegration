using LTLintegration.Tools;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTLintegration.Controllers
{
    public class LTLintegrationController : Controller
    {
        private string apiKey = AppSettings.ShopifyApiKey;
        private string secretKey = AppSettings.ShopifySecretKey;
        private string appUrl = AppSettings.AppUrl;

        // GET: LTLintegration
        public ActionResult install(string shop, string signature, string timestamp)
        {

            string r = string.Format("https://{0}/admin/oauth/authorize?client_id={1}&scope=read_shipping,write_shipping&redirect_uri=https://{2}/LTLintegration/auth", shop, apiKey, appUrl);
            return Redirect(r);

        }
        public ActionResult auth(string shop, string code)
        {
            string u = string.Format("https://{0}/admin/oauth/access_token", shop);

            var client = new RestClient(u);

            var request = new RestRequest(Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/x-www-form-urlencoded", "client_id=" + apiKey + "&client_secret=" + secretKey + "&code=" + code, ParameterType.RequestBody);

            var response = client.Execute(request);

            var r = JsonConvert.DeserializeObject<dynamic>(response.Content);
            var access = r.access_token;
            return View();
        }
    }
}