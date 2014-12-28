using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Http;
using Persona.Configurations;

namespace Persona
{
    /// <summary>
    ///     Foundation for Web APIs.
    /// </summary>
    /// <copyright file="/WebApiApplication.cs">
    ///     The MIT License (MIT)
    /// 
    ///     Copyright (c) 2014 Cyril Schumacher.fr
    ///     Permission is hereby granted, free of charge, to any person obtaining a copy
    ///     of this software and associated documentation files (the "Software"), to deal
    ///     in the Software without restriction, including without limitation the rights
    ///     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    ///     copies of the Software, and to permit persons to whom the Software is
    ///     furnished to do so, subject to the following conditions:
    /// 
    ///     The above copyright notice and this permission notice shall be included in all
    ///     copies or substantial portions of the Software.
    /// 
    ///     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    ///     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    ///     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    ///     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    ///     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    ///     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    ///     SOFTWARE.
    /// </copyright>
    /// <author>Cyril Schumacher</author>
    /// <date>28/12/2014T13:56:55+01:00</date>
    public class WebApiApplication : HttpApplication
    {
        #region Methods.

        #region Private methods.

        /// <summary>
        ///     Initialize security.
        /// </summary>
        /// <param name="response">HTTP response.</param>
        private static void _InitializeSecurity(HttpResponse response)
        {
            // Deletes HTTP headers.
            // Indicates the type of server running.
            response.Headers.Set("Server", string.Empty);
            // Gets the version of ASP.NET.
            response.Headers.Remove("X-AspNet-Version");
            // Gets the version of ASP.NET MVC framework.
            response.Headers.Remove("X-AspNetMvc-Version");
        }

        #endregion Private methods.

        /// <summary>
        ///     Occurs when the application starts.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfiguration.Register);
        }

        /// <summary>
        ///     Occurs just before ASP.NET sends HTTP headers to the client.
        /// </summary>
        protected void Application_PreSendRequestHeaders()
        {
            _InitializeSecurity(Response);
        }

        #endregion Methods.
    }
}