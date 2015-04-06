using System.Data.Entity;
using Warehouse.Model.Entities;

namespace Warehouse.DataProvider.Database
{
    public class MySqlMembershipContext : DbContext
    {
        public MySqlMembershipContext()
            : this("WarehouseContext")
        { }

        public MySqlMembershipContext(string connectionName)
            : base(connectionName)
        { }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<OAuthMembership> OAuthMemberships { get; set; }
        public DbSet<OAuthToken> OAuthTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersInRoles> UsersInRoles { get; set; }
    }
}