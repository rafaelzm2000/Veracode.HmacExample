using System;
using System.Net;

namespace Veracode.HmacExample.App
{
    public class Program
    {
        private const string AuthorizationHeader = "Authorization";
        private const string ApiId = "a9ed595307b546090ccfe6e11f159bbe";
        private const string ApiKey = "d7a7f43393deb511091c9eee03a2a573cedd740a1d7a5a8d09aae22c83c3c4d75808a57eb4c1e4100476db8feafb14ef25752be2cc912fed8e13878d4548ab76";

        public static void Main(string[] args)
        {
            try
            {
                const string urlBase = "analysiscenter.veracode.com";
                const string urlPath = "/api/5.0/getapplist.do";
                var urlParams = string.Empty;
                const string httpVerb = "GET"; //foodfgdfgdfgdfgdfgdsfgsdfgsd

                var webClient = new WebClient
                {
                    BaseAddress = $"https://{urlBase}"
                };

                var authorization = HmacAuthHeader.HmacSha256.CalculateAuthorizationHeader(ApiId, ApiKey, urlBase, urlPath, urlParams, httpVerb);

                webClient.Headers.Add(AuthorizationHeader, authorization);

                var result = webClient.DownloadString(urlPath);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
