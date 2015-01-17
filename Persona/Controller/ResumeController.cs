using System;
using System.Collections;
using Persona.Model;
using Persona.Model.Resume.Experience;
using Persona.Service;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Persona.Controller
{
    /// <summary>
    ///     Controller for resume information.
    /// </summary>
    /// <copyright file="/Controllers/ResumeController.cs">
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
    /// <date>28/12/2014T14:13:42+01:00</date>
    public class ResumeController : ApiController
    {
        #region Fields.

        /// <summary>
        ///     Service.
        /// </summary>
        private readonly ResumeService _service;

        #endregion Fields.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <see cref="ResumeController(ResumeService)"/>
        public ResumeController()
            : this(new ResumeService())
        {
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="service">Service.</param>
        public ResumeController(ResumeService service)
        {
            _service = service;
        }

        #endregion Constructors.

        /// <summary>
        ///     Returns all information.
        /// </summary>
        /// <returns>Profile information.</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        /// <summary>
        ///     Returns profile information.
        /// </summary>
        /// <returns>The profile information.</returns>
        [HttpGet]
        public HttpResponseMessage Profile()
        {
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        /// <summary>
        ///     Returns education information.
        /// </summary>
        /// <returns>The education information.</returns>
        [HttpGet]
        public HttpResponseMessage Education()
        {
            var value = _service.GetEducation();
            return Request.CreateResponse(HttpStatusCode.OK, new Response<IEnumerable>(HttpStatusCode.OK, value));
        }

        /// <summary>
        ///     Returns experience information.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>The experience information.</returns>
        [HttpGet]
        public HttpResponseMessage Experience(String id = null)
        {
            if (id == null)
            {
                var value = _service.GetExperience();
                return Request.CreateResponse(HttpStatusCode.OK, new Response<IEnumerable>(HttpStatusCode.OK, value));
            }
            else
            {
                var value = _service.GetExperience(id);
                return Request.CreateResponse(HttpStatusCode.OK, new Response<Company>(HttpStatusCode.OK, value));
            }
        }

        /// <summary>
        ///     Returns skills information.
        /// </summary>
        /// <returns>The skills information.</returns>
        [HttpGet]
        public HttpResponseMessage Skills()
        {
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}