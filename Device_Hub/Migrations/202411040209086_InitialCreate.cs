namespace Device_Hub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ativo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(nullable: false, maxLength: 350),
                        Fabricante = c.String(),
                        Modelo = c.String(nullable: false),
                        NumeroSerie = c.String(nullable: false),
                        DataAquisicao = c.DateTime(nullable: false),
                        Valor = c.Single(nullable: false),
                        Localizacao = c.String(),
                        Status = c.String(),
                        ResponsavelId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId)
                .ForeignKey("dbo.Funcionario", t => t.ResponsavelId)
                .Index(t => t.ResponsavelId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 110),
                        Cargo = c.String(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        Email = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 110),
                        Contato = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Garantia",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                        AtivoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ativo", t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId)
                .Index(t => t.Id)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Licenca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 110),
                        Tipo = c.String(nullable: false),
                        NumeroSerie = c.String(nullable: false),
                        DataAquisicao = c.DateTime(nullable: false),
                        DataExpiracao = c.DateTime(nullable: false),
                        Software = c.String(),
                        AtivoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ativo", t => t.AtivoId)
                .Index(t => t.AtivoId);
            
            CreateTable(
                "dbo.Manutencao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        Custo = c.Single(nullable: false),
                        AtivoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ativo", t => t.AtivoId)
                .Index(t => t.AtivoId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Ativo", "ResponsavelId", "dbo.Funcionario");
            DropForeignKey("dbo.Manutencao", "AtivoId", "dbo.Ativo");
            DropForeignKey("dbo.Licenca", "AtivoId", "dbo.Ativo");
            DropForeignKey("dbo.Garantia", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Garantia", "Id", "dbo.Ativo");
            DropForeignKey("dbo.Ativo", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Ativo", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Funcionario", "DepartamentoId", "dbo.Departamento");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Manutencao", new[] { "AtivoId" });
            DropIndex("dbo.Licenca", new[] { "AtivoId" });
            DropIndex("dbo.Garantia", new[] { "FornecedorId" });
            DropIndex("dbo.Garantia", new[] { "Id" });
            DropIndex("dbo.Funcionario", new[] { "DepartamentoId" });
            DropIndex("dbo.Ativo", new[] { "FornecedorId" });
            DropIndex("dbo.Ativo", new[] { "DepartamentoId" });
            DropIndex("dbo.Ativo", new[] { "ResponsavelId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Manutencao");
            DropTable("dbo.Licenca");
            DropTable("dbo.Garantia");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Departamento");
            DropTable("dbo.Ativo");
        }
    }
}
