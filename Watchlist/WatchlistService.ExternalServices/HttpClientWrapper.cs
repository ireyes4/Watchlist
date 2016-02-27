using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WatchlistService.ExternalServices
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient _client = null;
        
        public HttpClientWrapper()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// Deletes resource
        /// </summary>
        /// <typeparam name="TOutput">Expected output from DELETE call</typeparam>
        /// <param name="requestURI">URI of DELETE call</param>
        /// <returns></returns>
        TOutput IHttpClientWrapper.Delete<TOutput>(string requestURI)
        {
            using (_client)
            {
                try
                {
                    var resp = _client.DeleteAsync(requestURI).Result;
                    resp.EnsureSuccessStatusCode();

                    return resp.Content.ReadAsAsync<TOutput>().Result;

                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// GETs resource
        /// </summary>
        /// <typeparam name="TOutput">Expected output (Deserialized) of GET call</typeparam>
        /// <param name="requestURI">URI of GET call</param>
        /// <returns></returns>
        TOutput IHttpClientWrapper.Get<TOutput>(string requestURI)
        {
            using (_client)
            {
                try
                {
                    var resp = _client.GetAsync(requestURI).Result;
                    resp.EnsureSuccessStatusCode();

                    return resp.Content.ReadAsAsync<TOutput>().Result;

                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Creates resource
        /// </summary>
        /// <typeparam name="TInput">Expected type of input to POST call</typeparam>
        /// <typeparam name="TOutput">Expected type of output to POST call</typeparam>
        /// <param name="requestURI">URI of REST call</param>
        /// <param name="inputValue">Deserialized input object</param>
        /// <returns></returns>
        TOutput IHttpClientWrapper.Post<TInput, TOutput>(string requestURI, TInput inputValue)
        {
            using (_client)
            { 
                try
                {
                    var resp = _client.PostAsJsonAsync<TInput>(requestURI, inputValue).Result;
                    resp.EnsureSuccessStatusCode();

                    return resp.Content.ReadAsAsync<TOutput>().Result;

                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Updates resource
        /// </summary>
        /// <typeparam name="TInput">Expected type (deserialized) of input to PUT call</typeparam>
        /// <typeparam name="TOutput">Expected type (deserialized) of output from PUT call</typeparam>
        /// <param name="requestURI">URI of PUT call</param>
        /// <param name="inputValue">Deserialized input object</param>
        /// <returns></returns>
        TOutput IHttpClientWrapper.Put<TInput, TOutput>(string requestURI, TInput inputValue)
        {
            using (_client)
            {
                try
                {
                    var resp = _client.PutAsJsonAsync<TInput>(requestURI, inputValue).Result;
                    resp.EnsureSuccessStatusCode();

                    return resp.Content.ReadAsAsync<TOutput>().Result;

                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
