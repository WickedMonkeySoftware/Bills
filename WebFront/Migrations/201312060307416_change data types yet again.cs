namespace WebFront.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatatypesyetagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incomes", "NextEvent", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incomes", "NextEvent", c => c.Time(nullable: false, precision: 7));
        }
    }
}
