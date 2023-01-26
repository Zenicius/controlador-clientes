namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "DataExpedicao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "DataExpedicao", c => c.DateTime(nullable: false));
        }
    }
}
