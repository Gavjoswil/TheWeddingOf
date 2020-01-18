namespace TheWeddingOf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attempt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rsvp", "Comments", c => c.String());
            DropColumn("dbo.Rsvp", "GroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rsvp", "GroupId", c => c.Int(nullable: false));
            DropColumn("dbo.Rsvp", "Comments");
        }
    }
}
