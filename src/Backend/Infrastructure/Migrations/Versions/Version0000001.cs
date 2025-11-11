

using FluentMigrator;

namespace Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_USER, "Criar tabela para salvar os dados de usuario")]
    public class Version0000001 : VersionBase
    {
        public override void Up()
        {
                CreateTable("Usuarios")
                .WithColumn("Nome").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Senha").AsString(2000).NotNullable();
        }
    }
}