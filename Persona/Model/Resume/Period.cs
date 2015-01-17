using System;

namespace Persona.Model.Resume
{
    /// <summary>
    ///     Represents a period between start and end date.
    /// </summary>
    public class Period
    {
        /// <summary>
        ///     Start date.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        ///     End date.
        /// </summary>
        public DateTime End { get; set; }
    }
}