using System;

namespace Persona.Model.Resume.Experience
{
    /// <summary>
    /// 
    /// </summary>
    public class Company
    {
        /// <summary>
        ///     Gets or sets a name of company.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets a period.
        /// </summary>
        public Period Period { get; set; }

        /// <summary>
        ///     Gets or sets a summary.
        /// </summary>
        public String Summary { get; set; }

        /// <summary>
        ///     Gets or sets a location.
        /// </summary>
        public Location Location { get; set; }
    }
}