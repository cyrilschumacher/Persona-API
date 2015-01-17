using System.Collections.Generic;

namespace Persona.Services.FileDatabase
{
    /// <summary>
    ///     Interface for generic CRUD operations on a repository for a specific type.
    /// </summary>
    /// <typeparam name="TIdentifier">Type of identifier.</typeparam>
    /// <typeparam name="TInstance">Type of entity.</typeparam>
    /// <copyright file="/Services/FileDatabase/ICrudFileRepository.cs">
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
    public interface ICrudFileRepository<in TIdentifier, out TInstance>
    {
        #region Properties.

        /// <summary>
        ///     Gets a 32-bit integer that represents the number of entities available.
        /// </summary>
        long Length { get; set; }

        #endregion Properties.

        #region Methods.

        /// <summary>
        ///     Returns whether an entity with the given id exists.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>True if an entity with the given id exists, False otherwise.</returns>
        bool Exists(TIdentifier identifier);

        /// <summary>
        ///
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        TInstance Find(TIdentifier identifier);

        /// <summary>
        ///     Returns all instances of the type.
        /// </summary>
        /// <returns>All entities.</returns>
        IEnumerable<TInstance> FindAll();

        #endregion Methods.
    }
}