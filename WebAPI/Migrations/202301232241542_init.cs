namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false),
                        EstadoCivil = c.String(nullable: false),
                        RG = c.String(),
                        DataExpedicao = c.DateTime(nullable: false),
                        OrgaoExpedicao = c.String(),
                        UFExpedicao = c.String(),
                        CEP = c.String(nullable: false),
                        Logradouro = c.String(nullable: false),
                        Numero = c.String(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        UF = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
