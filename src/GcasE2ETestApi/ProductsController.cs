using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace GcasE2ETestApi;

[ApiController]
[Route("api/products")]
public sealed class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string name)
    {
        using var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        using var command = connection.CreateCommand();
        // Intentionally vulnerable: untrusted input is concatenated into SQL.
        // FIXED: Parameterized SQL query prevents SQL injection
        command.CommandText = "SELECT 1 WHERE 'demo' = @name";
        command.Parameters.AddWithValue("@name", name ?? string.Empty);
        var result = command.ExecuteScalar();

        return Ok(new { matched = result is not null });
    }
}
