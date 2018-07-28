namespace IMS_2018_07_25.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcosttoitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Cost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Cost");
        }
    }
}
