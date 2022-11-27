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