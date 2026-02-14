using System.Net;

namespace Zeega.Infrastructure {
    /// <summary>
    /// Extended http request exceptin with http status code
    /// </summary>
    public class HttpRequestExtException : HttpRequestException {

        /// <summary>
        /// Gets status code of HTTP reponse
        /// </summary>
        public HttpStatusCode StatusCode { get; protected set; }

        #region Constructors and Init

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Net.Http.HttpRequestException"/> class.
        /// </summary>
        /// <param name="statusCode">Status code of HTTP response</param>
        public HttpRequestExtException(HttpStatusCode statusCode) {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Net.Http.HttpRequestException"/> class with a specific message that describes the current exception.
        /// </summary>
        /// <param name="statusCode">Status code of HTTP response</param>
        /// <param name="message">A message that describes the current exception.</param>
        public HttpRequestExtException(HttpStatusCode statusCode, string message) : base(message) {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Net.Http.HttpRequestException"/> class with a specific message that describes the current exception and an inner exception.
        /// </summary>
        /// <param name="statusCode">Status code of HTTP response</param>
        /// <param name="message">A message that describes the current exception.</param>
        /// <param name="inner">The inner exception.</param>
        public HttpRequestExtException(HttpStatusCode statusCode, string message, Exception inner) : base(message, inner) {
            StatusCode = statusCode;
        }

        #endregion
    }
}
