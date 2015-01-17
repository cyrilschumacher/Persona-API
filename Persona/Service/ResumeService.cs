using System;
using Persona.Model.Resume.Education;
using Persona.Model.Resume.Experience;
using Persona.Services.FileDatabase;
using System.Collections.Generic;
using System.Web;

namespace Persona.Service
{
    /// <summary>
    ///     Service for resume information.
    /// </summary>
    /// <copyright file="/Service/ResumeService.cs">
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
    /// <date>10/01/2014T12:00:32+01:00</date>
    public class ResumeService
    {
        #region Constants.

        /// <summary>
        ///     Path to resume database.
        /// </summary>
        private const string ResumeDatabasePath = "~/App_Data/Resume/";

        #endregion Constants.

        #region Fields.

        /// <summary>
        ///     Database.
        /// </summary>
        private readonly Database _database;

        #endregion Fields.

        #region Constructors.

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <see cref="ResumeService(Database)"/>
        public ResumeService()
            : this(new Database(HttpContext.Current.Server.MapPath(ResumeDatabasePath)))
        {
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="database">The database.</param>
        public ResumeService(Database database)
        {
            _database = database;
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        ///     Returns the education section.
        /// </summary>
        /// <returns>The education section.</returns>
        public IEnumerable<School> GetEducation()
        {
            var table = _database.Get<string, School>("Education");
            return table.FindAll();
        }

        /// <summary>
        ///     Returns the experience section.
        /// </summary>
        /// <returns>The experience section.</returns>
        public IEnumerable<Company> GetExperience()
        {
            var table = _database.Get<string, Company>("Experience");
            return table.FindAll();
        }

        /// <summary>
        ///     Returns the experience section.
        /// </summary>
        /// <returns>The experience section.</returns>
        public Company GetExperience(String id)
        {
            var table = _database.Get<string, Company>("Experience");
            return table.Find(id);
        } 

        #endregion Methods.
    }
}