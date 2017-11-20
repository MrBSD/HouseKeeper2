namespace HouseKeeper2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'70207670-f25b-4080-a30a-53c264b5002f', N'guest@housekeeper.com', 0, N'ALHuaJe+Sm8SZk42NG7OLVDCgoxMCKx+kwfmzCMrpsvlX3Ovp8xNXTvYe3523KuI3g==', N'92500199-f8dd-4899-8047-21a109423fb9', NULL, 0, 0, NULL, 1, 0, N'guest@housekeeper.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'732a5378-aa6c-4572-be86-110d5f2676c5', N'admin@housekeeper.com', 0, N'APaMAg2V3VC1bi0C3umSMT4U7Or+wmiIm/VppFPM8R96cyBVJV/wlULckQ8J0F2kbQ==', N'c0ae5674-2d0d-4111-a66e-6924bf6c6cd7', NULL, 0, 0, NULL, 1, 0, N'admin@housekeeper.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'40f49d3e-ad97-449f-988a-96c4fdffc8b3', N'Admin')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'732a5378-aa6c-4572-be86-110d5f2676c5', N'40f49d3e-ad97-449f-988a-96c4fdffc8b3')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
