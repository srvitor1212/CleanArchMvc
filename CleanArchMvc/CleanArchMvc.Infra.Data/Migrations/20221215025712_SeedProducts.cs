using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //DateTime agora = DateTime.Now;
            string agora = "12/15/2022 00:00:00";

            migrationBuilder.Sql(
                "INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId, CreatedDate) " +
                "VALUES ('Caderno azul', 'Caderno de 10 materias azul', 12.99, 50, 'caderno1.jpg', 1, '" + agora + "')");

            migrationBuilder.Sql(
                "INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId, CreatedDate) " +
                "VALUES ('Borracha', 'Borraccha comum', 1.99, 50, 'borracha1.jpg', 1, '" + agora + "')");

            migrationBuilder.Sql(
                "INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId, CreatedDate) " +
                "VALUES ('Estojo', 'Estojo do DBZ', 20.45, 10, 'estojoDBZ1.jpg', 1, '" + agora + "')");

            migrationBuilder.Sql(
                "INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId, CreatedDate) " +
                "VALUES ('Calculadora', 'Calcudadora escolar', 9.99, 30, 'calc1.jpg', 2, '" + agora + "')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Procuts");
        }
    }
}
