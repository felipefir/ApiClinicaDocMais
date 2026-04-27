using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinicaDocMais.Migrations
{
    /// <inheritdoc />
    public partial class agendamentoCorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "Crm",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "especialidadeMedico",
                table: "agendamentos");

            migrationBuilder.RenameColumn(
                name: "nomePaciente",
                table: "agendamentos",
                newName: "cpfPacinte");

            migrationBuilder.RenameColumn(
                name: "nomeMedico",
                table: "agendamentos",
                newName: "CrmMedico");

            migrationBuilder.AddColumn<string>(
                name: "Medicocrm",
                table: "agendamentos",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "pacientecpf",
                table: "agendamentos",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_Medicocrm",
                table: "agendamentos",
                column: "Medicocrm");

            migrationBuilder.CreateIndex(
                name: "IX_agendamentos_pacientecpf",
                table: "agendamentos",
                column: "pacientecpf");

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_medicos_Medicocrm",
                table: "agendamentos",
                column: "Medicocrm",
                principalTable: "medicos",
                principalColumn: "crm");

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_pacientes_pacientecpf",
                table: "agendamentos",
                column: "pacientecpf",
                principalTable: "pacientes",
                principalColumn: "cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_medicos_Medicocrm",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_pacientes_pacientecpf",
                table: "agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_agendamentos_Medicocrm",
                table: "agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_agendamentos_pacientecpf",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "Medicocrm",
                table: "agendamentos");

            migrationBuilder.DropColumn(
                name: "pacientecpf",
                table: "agendamentos");

            migrationBuilder.RenameColumn(
                name: "cpfPacinte",
                table: "agendamentos",
                newName: "nomePaciente");

            migrationBuilder.RenameColumn(
                name: "CrmMedico",
                table: "agendamentos",
                newName: "nomeMedico");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "agendamentos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Crm",
                table: "agendamentos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "agendamentos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "especialidadeMedico",
                table: "agendamentos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
