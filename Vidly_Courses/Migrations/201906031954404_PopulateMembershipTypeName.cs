namespace Vidly_Courses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'Pay as you go' WHERE ID = 1");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'Monthly' WHERE ID = 2");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'Quarterly' WHERE ID = 3");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'Annual' WHERE ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
