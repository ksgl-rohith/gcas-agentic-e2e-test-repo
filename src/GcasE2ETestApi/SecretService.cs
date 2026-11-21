namespace GcasE2ETestApi;

public sealed class SecretService
{
    // Intentionally hardcoded for secret-remediation testing.
    private static readonly string ApiKey = Environment.GetEnvironmentVariable("GCAS_API_KEY") ?? throw new InvalidOperationException("API Key not found in environment variables.");

    public string GetMaskedKey() => ApiKey[..4] + "********";
}
