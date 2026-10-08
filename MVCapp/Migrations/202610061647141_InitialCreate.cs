namespace MVCapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usagers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(nullable: false),
                        NomFam = c.String(nullable: false),
                        Rue = c.String(nullable: false),
                        Ville = c.String(nullable: false),
                        Province = c.String(nullable: false),
                        CodePostal = c.String(nullable: false),
                        NoTel = c.String(nullable: false),
                        TelExt = c.String(),
                        Courriel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usagers");
        }
    }
}
