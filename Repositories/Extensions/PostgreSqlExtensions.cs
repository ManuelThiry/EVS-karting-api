using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Repositories.Extensions;

public static class PostgreSqlExtensions
{
    /// <summary>
    /// Reset all PostgreSQL sequences to match the max ID in their tables.
    /// This is necessary when using HasData() with explicit IDs.
    /// </summary>
    public static void ResetPostgreSqlSequences(this DbContext context)
    {
        if (context.Database.IsNpgsql())
        {
            try
            {
                // Query each table separately with proper escaping
                var queries = new[]
                {
                    "SELECT setval(pg_get_serial_sequence('\"Drivers\"', 'Id'), COALESCE((SELECT MAX(\"Id\") FROM \"Drivers\"), 1), true)",
                    "SELECT setval(pg_get_serial_sequence('\"Tracks\"', 'Id'), COALESCE((SELECT MAX(\"Id\") FROM \"Tracks\"), 1), true)",
                    "SELECT setval(pg_get_serial_sequence('\"Races\"', 'Id'), COALESCE((SELECT MAX(\"Id\") FROM \"Races\"), 1), true)"
                };
                
                foreach (var query in queries)
                {
                    context.Database.ExecuteSqlRaw(query);
                }
                
                Console.WriteLine("PostgreSQL sequences reset successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not reset sequences: {ex.Message}");
            }
        }
    }
}
