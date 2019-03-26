using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModelDesigner.Designer.Host.Migrations
{
    public partial class RenambTbName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndexDesc_tbAggRoots_AggRootObjectAggRootId",
                table: "IndexDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_IndexDesc_tbEntities_EntityObjectAggRootId",
                table: "IndexDesc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbEntities",
                table: "tbEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbAggRoots",
                table: "tbAggRoots");

            migrationBuilder.RenameTable(
                name: "tbEntities",
                newName: "Entities");

            migrationBuilder.RenameTable(
                name: "tbAggRoots",
                newName: "AggRoots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AggRoots",
                table: "AggRoots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndexDesc_AggRoots_AggRootObjectAggRootId",
                table: "IndexDesc",
                column: "AggRootObjectAggRootId",
                principalTable: "AggRoots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndexDesc_Entities_EntityObjectAggRootId",
                table: "IndexDesc",
                column: "EntityObjectAggRootId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndexDesc_AggRoots_AggRootObjectAggRootId",
                table: "IndexDesc");

            migrationBuilder.DropForeignKey(
                name: "FK_IndexDesc_Entities_EntityObjectAggRootId",
                table: "IndexDesc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AggRoots",
                table: "AggRoots");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "tbEntities");

            migrationBuilder.RenameTable(
                name: "AggRoots",
                newName: "tbAggRoots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbEntities",
                table: "tbEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbAggRoots",
                table: "tbAggRoots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndexDesc_tbAggRoots_AggRootObjectAggRootId",
                table: "IndexDesc",
                column: "AggRootObjectAggRootId",
                principalTable: "tbAggRoots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndexDesc_tbEntities_EntityObjectAggRootId",
                table: "IndexDesc",
                column: "EntityObjectAggRootId",
                principalTable: "tbEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
