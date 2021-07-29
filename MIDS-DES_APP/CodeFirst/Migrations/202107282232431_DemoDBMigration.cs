namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DemoDBMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 10),
                        RFC = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        JobEmail = c.String(nullable: false, maxLength: 100),
                        JobPhoneNumber = c.String(maxLength: 10),
                        JobPosition = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Person", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "EmployeeID", "dbo.Person");
            DropIndex("dbo.Employee", new[] { "EmployeeID" });
            DropTable("dbo.Employee");
            DropTable("dbo.Person");
        }
    }
}
