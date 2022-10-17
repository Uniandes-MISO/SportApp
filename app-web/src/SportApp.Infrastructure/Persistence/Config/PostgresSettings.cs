using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Infrastructure.Persistence.Config
{
    public class PostgresSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public static string SectionName = "PostgresSettings";

        /// <summary>
        /// 
        /// </summary>
        public string? ConnectionString { get; set; }
    }
}
