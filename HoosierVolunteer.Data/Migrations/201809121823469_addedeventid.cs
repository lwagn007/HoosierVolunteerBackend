namespace HoosierVolunteer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedeventid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventId");
        }
    }
}
