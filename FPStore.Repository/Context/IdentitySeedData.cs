namespace FPStore.Repository.Context
{
    public static class IdentitySeedData
    {
        public static class Roles
        {
            public const string Member = "Member";      // Normal kullanıcılar için
            public const string StoreAdmin = "StoreAdmin"; // Mağaza yöneticileri için
            public const string SuperAdmin = "SuperAdmin"; // Sistem yöneticisi için
        }

        public static class DefaultSuperAdmin
        {
            public const string Email = "superadmin@fpshop.com";
            public const string Password = "SuperAdmin123!";
        }
    }
} 