using System.Collections.Generic;

namespace Persona.Model.Resume.Education
{
    /// <summary>
    ///     Represents a school.
    /// </summary>
    public class School
    {
        /// <summary>
        ///     Gets or sets a name of school.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets a period.
        /// </summary>
        public Period Period { get; set; }

        /// <summary>
        ///     Gets or sets a degree list.
        /// </summary>
        public List<string> Degrees { get; set; }

        /// <summary>
        ///     Gets or sets a location.
        /// </summary>
        public Location Location { get; set; }
    }
}