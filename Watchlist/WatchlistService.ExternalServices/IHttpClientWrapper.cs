using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchlistService.ExternalServices
{
    public interface IHttpClientWrapper
    {
        /// <summary>
        /// Creates resource
        /// </summary>
        /// <typeparam name="TInput">Expected type of input to POST call</typeparam>
        /// <typeparam name="TOutput">Expected type of output to POST call</typeparam>
        /// <param name="requestURI">URI of REST call</param>
        /// <param name="inputValue">Deserialized input object</param>
        /// <returns></returns>
        TOutput Post<TInput, TOutput>(string requestURI, TInput inputValue);

        /// <summary>
        /// GETs resource
        /// </summary>
        /// <typeparam name="TOutput">Expected output (Deserialized) of GET call</typeparam>
        /// <param name="requestURI">URI of GET call</param>
        /// <returns></returns>
        TOutput Get<TOutput>(string requestURI);

        /// <summary>
        /// Updates resource
        /// </summary>
        /// <typeparam name="TInput">Expected type (deserialized) of input to PUT call</typeparam>
        /// <typeparam name="TOutput">Expected type (deserialized) of output from PUT call</typeparam>
        /// <param name="requestURI">URI of PUT call</param>
        /// <param name="inputValue">Deserialized input object</param>
        /// <returns></returns>
        TOutput Put<TInput, TOutput>(string requestURI, TInput inputValue);

        /// <summary>
        /// Deletes resource
        /// </summary>
        /// <typeparam name="TOutput">Expected output from DELETE call</typeparam>
        /// <param name="requestURI">URI of DELETE call</param>
        /// <returns></returns>
        TOutput Delete<TOutput>(string requestURI);
    }
}
