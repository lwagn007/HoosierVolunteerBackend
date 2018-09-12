namespace HoosierVolunteer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uneedtomigwate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Birthday");
            DropColumn("dbo.AspNetUsers", "AccountCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AccountCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
