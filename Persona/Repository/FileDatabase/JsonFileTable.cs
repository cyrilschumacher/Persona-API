using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Persona.Services.FileDatabase
{
    /// <summary>
    ///     Json file table.
    /// </summary>
    /// <copyright file="/Services/FileDatabase/JsonFileTable.cs">
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
    /// <date>02/01/2015T11:54:43+01:00</date>
    public class JsonFileTable<TIdentifier, TInstance> : ICrudFileRepository<TIdentifier, TInstance>
    {
        #region Fields.

        /// <summary>
        ///     Path to database.
        /// </summary>
        private readonly string _path;

        #endregion Fields.

        #region Constructor section.

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="databasePath">The path to the database.</param>
        /// <param name="tableName">The name of table.</param>
        public JsonFileTable(string databasePath, string tableName)
        {
            _path = Path.Combine(databasePath, tableName);
            _AssertTablePath(_path);
        }

        #endregion Constructor section.

        #region Methods.

        #region Private methods.

        /// <summary>
        ///     Asserts that the table path exists.
        /// </summary>
        /// <param name="tablePath">The path to table.</param>
        private static void _AssertTablePath(string tablePath)
        {
            if (!Directory.Exists(tablePath))
            {
                throw new InvalidOperationException("No table exists under that name.");
            }
        }

        /// <summary>
        ///     Asserts that the row exists in the table.
        /// </summary>
        /// <param name="identifier">The identifier of row.</param>
        private void _AssertTableRow(string identifier)
        {
            var files = Directory.GetFiles(_path);
            if (files.Select(Path.GetFileNameWithoutExtension).Any(fileNameWithoutExtension => fileNameWithoutExtension != null && fileNameWithoutExtension.Equals(identifier)))
            {
                return;
            }

            throw new InvalidOperationException("No identifier exists.");
        }

        /// <summary>
        ///     Gets the rows.
        /// </summary>
        /// <returns>The rows.</returns>
        private IEnumerable<string> _GetRows()
        {
            return Directory.GetFiles(_path).ToList();
        }

        /// <summary>
        ///     Gets the specified row by its identifier.
        /// </summary>
        /// <param name="identifier">The identifier of row.</param>
        /// <returns>The row.</returns>
        private string _GetRow(string identifier)
        {
            _AssertTableRow(identifier);

            var files = Directory.GetFiles(_path);
            foreach (var stream in from file in files let fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file) where (fileNameWithoutExtension != null) && fileNameWithoutExtension.Equals(identifier) select new StreamReader(file))
            {
                return stream.ReadToEnd();
            }

            throw new InvalidOperationException("No identifier exists.");
        }

        /// <summary>
        ///     Converts a row to a entity.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="content">Row content.</param>
        /// <returns>The entity.</returns>
        private static T _ConvertTo<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        #endregion Private methods.

        /// <summary>
        ///
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        ///     Returns whether an entity with the given id exists.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>True if an entity with the given id exists, False otherwise.</returns>
        public bool Exists(TIdentifier identifier)
        {
            var rows = _GetRows();
            return rows.Any(row =>
            {
                var tableName = Path.GetFileNameWithoutExtension(row);
                return (tableName != null) && tableName.Equals(identifier);
            });
        }

        /// <summary>
        ///     Retrieves an entity by its id.
        /// </summary>
        /// <param name="identifier">The identifier of the row.</param>
        /// <returns>The entity with the given id.</returns>
        public TInstance Find(TIdentifier identifier)
        {
            var row = _GetRow(identifier.ToString());
            return _ConvertTo<TInstance>(row);
        }

        /// <summary>
        ///     Returns all instances of the type.
        /// </summary>
        /// <returns>All entities.</returns>
        public IEnumerable<TInstance> FindAll()
        {
            var rows = _GetRows();
            return (from row in rows select new StreamReader(row) into stream select stream.ReadToEnd() into content select _ConvertTo<TInstance>(content)).ToList();
        }

        #endregion Methods.
    }
}