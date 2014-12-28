using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Persona.Controllers
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
        /// <summary>
        ///     Returns profile information.
        /// </summary>
        /// <returns>Profile information.</returns>
        [HttpGet]
        [Route("resume/profile/"), ResponseType(typeof(object))]
        public HttpResponseMessage GetProfile()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns education information.
        /// </summary>
        /// <returns>Education information.</returns>
        [HttpGet]
        [Route("resume/education/"), ResponseType(typeof(object))]
        public HttpResponseMessage GetEducation()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns experience information.
        /// </summary>
        /// <returns>Experience information.</returns>
        [HttpGet]
        [Route("resume/experience/"), ResponseType(typeof(object))]
        public HttpResponseMessage GetExperience()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns skills information.
        /// </summary>
        /// <returns>Skills information.</returns>
        [HttpGet]
        [Route("resume/skills/"), ResponseType(typeof(object))]
        public HttpResponseMessage GetSkills()
        {
            throw new NotImplementedException();
        }
    }
}
