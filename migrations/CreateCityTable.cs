using FluentMigrator;

namespace migrations
{
    [Migration(0)]
    public class CreateCityTable : Migration
    {
        public override void Up()
        {
            Create.Table("City")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("Population").AsInt64().Nullable();
        }
        public override void Down()
        {
            Delete.Table("City");
        }

    }
}
