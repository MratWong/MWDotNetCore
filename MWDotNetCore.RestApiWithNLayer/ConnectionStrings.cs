using System.Data.SqlClient;

namespace MWDotNetCore.RestApiWithNLayer;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "DotNetTrainingBatch4",
        UserID = "sa",
        Password = "sasa@123",
        TrustServerCertificate = true
    };
}
