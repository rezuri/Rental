using System.Data.Entity.SqlServer;

namespace Rental.DataAccess
{
    internal static class EfHack
    {
        private static SqlProviderServices _instance = SqlProviderServices.Instance;
    }
}
