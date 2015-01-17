using System.IO;

namespace Persona.Services.FileDatabase
{
    /// <summary>
    ///
    /// </summary>
    /// <copyright file="/Services/FileDatabase/Database.cs">
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
    public class Database
    {
        #region Fields.

        /// <summary>
        ///     Path to database.
        /// </summary>
        private readonly string _databasePath;

        #endregion Fields.

        #region Constructor section.

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="databasePath">Path to database.</param>
        public Database(string databasePath)
        {
            _databasePath = databasePath;
        }

        #endregion Constructor section.

        #region Methods.

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exists(string name)
        {
            var path = Path.Combine(_databasePath, name);
            return Directory.Exists(path);
        }

        /// <summary>
        ///     Gets the table.
        /// </summary>
        /// <typeparam name="TIdentifier">The identifier row of the table.</typeparam>
        /// <typeparam name="TInstance">The entity of the table.</typeparam>
        /// <returns>The table.</returns>
        public ICrudFileRepository<TIdentifier, TInstance> Get<TIdentifier, TInstance>(string tableName)
        {
            return new JsonFileTable<TIdentifier, TInstance>(_databasePath, tableName);
        }

        /// <summary>
        ///     Gets a 32-bit integer that represents the total number of table available.
        /// </summary>
        public long Length
        {
            get { return Directory.GetDirectories(_databasePath).Length; }
        }

        #endregion Methods.
    }
}