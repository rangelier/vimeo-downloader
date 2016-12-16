using System.Collections.Generic;
using System.Linq;

namespace VimeoDownloader.Models
{
    /// <summary>
    /// Class File.
    /// </summary>
    public class File
    {
        /// <summary>
        /// Gets or sets the progressive.
        /// </summary>
        /// <value>The progressive.</value>
        public IEnumerable<Progressive> Progressive { get; set; }

        /// <summary>
        /// Sorts this instance.
        /// </summary>
        internal void Sort()
        {
            Progressive = Progressive.OrderByDescending(x => x.Height);
        }
    }
}
