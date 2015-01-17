using System;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Routing;

namespace Persona.Configuration
{
    /// <summary>
    ///     Managing Web APIs.
    /// </summary>
    /// <copyright file="/Configurations/WebApiApplication.cs">
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
    public static class WebApiConfiguration
    {
        #region Methods.

        #region Private methods.

        /// <summary>
        ///     Asserts the HTTP configuration is not null.
        /// </summary>
        /// <param name="configuration">HTTP configuration.</param>
        private static void _AssertHttpConfiguration(HttpConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }
        }

        /// <summary>
        ///     Initialize HTTP itineraries.
        /// </summary>
        /// <param name="routes">Collection of instances <see cref="IHttpRoute"/>.</param>
        private static void _InitializeRoute(HttpRouteCollection routes)
        {
            routes.MapHttpRoute("default", "{controller}/{action}/{id}", new { id = RouteParameter.Optional });
        }

        /// <summary>
        ///     Initialize Route table.
        /// </summary>
        private static void _InitializeRouteTable()
        {
            RouteTable.Routes.LowercaseUrls = true;
            RouteTable.Routes.AppendTrailingSlash = true;
        }

        #endregion Private methods.

        /// <summary>
        ///     Registers API.
        /// </summary>
        /// <param name="configuration">HTTP configuration.</param>
        /// <exception cref="System.ArgumentNullException">Throws if <paramref name="configuration"/> is null.</exception>
        public static void Register(HttpConfiguration configuration)
        {
            // Checks if the HTTP configuration is not null.
            _AssertHttpConfiguration(configuration);

            // Enables the routage.
            configuration.MapHttpAttributeRoutes();

            // Initialize HTTP itineraries.
            _InitializeRouteTable();
            _InitializeRoute(configuration.Routes);

        }

        #endregion Methods.
    }
}