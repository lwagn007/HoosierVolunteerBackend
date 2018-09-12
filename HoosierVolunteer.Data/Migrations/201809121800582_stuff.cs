namespace HoosierVolunteer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        CreatorId = c.Guid(nullable: false),
                        EventRange_Start = c.DateTime(nullable: false),
                        EventRange_End = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        EventTitle = c.String(),
                        VolunteersNeeded = c.Int(nullable: false),
                        AttendingVolunteers = c.Int(nullable: false),
                        EventDescription = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CreatorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
