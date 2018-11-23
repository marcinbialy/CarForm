using Microsoft.EntityFrameworkCore.Migrations;

namespace CarForm.Data.Migrations
{
    public partial class PopulateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CarMarks (Name) VALUES ('Mazda')");
            migrationBuilder.Sql("INSERT INTO CarMarks (Name) VALUES ('BMW')");
            migrationBuilder.Sql("INSERT INTO CarMarks (Name) VALUES ('Audi')");

            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('Model 3', (SELECT ID FROM CarMarks WHERE Name = 'Mazda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('Model 5', (SELECT ID FROM CarMarks WHERE Name = 'Mazda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('323', (SELECT ID FROM CarMarks WHERE Name = 'Mazda'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('M3', (SELECT ID FROM CarMarks WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('Series 5', (SELECT ID FROM CarMarks WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('X4', (SELECT ID FROM CarMarks WHERE Name = 'BMW'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('A3', (SELECT ID FROM CarMarks WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('A5', (SELECT ID FROM CarMarks WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, CarMarkId) VALUES ('Coupe', (SELECT ID FROM CarMarks WHERE Name = 'Audi'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CarMarks WHERE Name IN ('Mazda','BMW','Audi')");
        }
    }
}
