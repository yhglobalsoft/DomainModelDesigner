using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModelDesigner.Designer.Host.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ApplicationName = table.Column<string>(maxLength: 96, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ImpersonatorUserId = table.Column<Guid>(nullable: true),
                    ImpersonatorTenantId = table.Column<Guid>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    ClientId = table.Column<string>(maxLength: 64, nullable: true),
                    CorrelationId = table.Column<string>(maxLength: 64, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    HttpMethod = table.Column<string>(maxLength: 16, nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    Exceptions = table.Column<string>(maxLength: 4000, nullable: true),
                    Comments = table.Column<string>(maxLength: 256, nullable: true),
                    HttpStatusCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpPermissionGrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissionGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2048, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAggRoots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(maxLength: 20, nullable: false),
                    FieldTypeId = table.Column<string>(maxLength: 36, nullable: false),
                    IsSimpleField = table.Column<bool>(nullable: false),
                    IsConstructorParameter = table.Column<bool>(nullable: false),
                    IsMultiple = table.Column<bool>(nullable: false),
                    FieldLen = table.Column<string>(maxLength: 10, nullable: false),
                    FieldDescription = table.Column<string>(maxLength: 255, nullable: false),
                    DomainEntityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descriptions = table.Column<string>(maxLength: 255, nullable: true),
                    IdIsKey = table.Column<bool>(nullable: false),
                    KeyFields = table.Column<string>(maxLength: 100, nullable: true),
                    IdTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAggRoots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(maxLength: 20, nullable: false),
                    FieldTypeId = table.Column<string>(maxLength: 36, nullable: false),
                    IsSimpleField = table.Column<bool>(nullable: false),
                    IsConstructorParameter = table.Column<bool>(nullable: false),
                    IsMultiple = table.Column<bool>(nullable: false),
                    FieldLen = table.Column<string>(maxLength: 10, nullable: false),
                    FieldDescription = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descriptions = table.Column<string>(maxLength: 255, nullable: true),
                    IdIsKey = table.Column<bool>(nullable: false),
                    KeyFields = table.Column<string>(maxLength: 100, nullable: true),
                    IdTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValueObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(maxLength: 20, nullable: false),
                    FieldTypeId = table.Column<string>(maxLength: 36, nullable: false),
                    IsSimpleField = table.Column<bool>(nullable: false),
                    IsConstructorParameter = table.Column<bool>(nullable: false),
                    IsMultiple = table.Column<bool>(nullable: false),
                    FieldLen = table.Column<string>(maxLength: 10, nullable: false),
                    FieldDescription = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Descriptions = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpAuditLogActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 128, nullable: true),
                    Parameters = table.Column<string>(maxLength: 2000, nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityId = table.Column<string>(maxLength: 128, nullable: false),
                    EntityTypeFullName = table.Column<string>(maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityChanges_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DomainName = table.Column<string>(maxLength: 20, nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    AppAggRootId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domains_Apps_AppAggRootId",
                        column: x => x.AppAggRootId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndexDesc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndexName = table.Column<string>(maxLength: 30, nullable: false),
                    IsUnique = table.Column<bool>(nullable: false),
                    Fields = table.Column<string>(nullable: true),
                    AggRootObjectAggRootId = table.Column<Guid>(nullable: true),
                    EntityObjectAggRootId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexDesc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexDesc_tbAggRoots_AggRootObjectAggRootId",
                        column: x => x.AggRootObjectAggRootId,
                        principalTable: "tbAggRoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndexDesc_tbEntities_EntityObjectAggRootId",
                        column: x => x.EntityObjectAggRootId,
                        principalTable: "tbEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    EntityChangeId = table.Column<Guid>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 128, nullable: false),
                    PropertyTypeFullName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogActions_AuditLogId",
                table: "AbpAuditLogActions",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_Execution~",
                table: "AbpAuditLogActions",
                columns: new[] { "TenantId", "ServiceName", "MethodName", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_UserId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "UserId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_AuditLogId",
                table: "AbpEntityChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                columns: new[] { "TenantId", "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_EntityChangeId",
                table: "AbpEntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissionGrants_Name_ProviderName_ProviderKey",
                table: "AbpPermissionGrants",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_Name_ProviderName_ProviderKey",
                table: "AbpSettings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_Domains_AppAggRootId",
                table: "Domains",
                column: "AppAggRootId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexDesc_AggRootObjectAggRootId",
                table: "IndexDesc",
                column: "AggRootObjectAggRootId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexDesc_EntityObjectAggRootId",
                table: "IndexDesc",
                column: "EntityObjectAggRootId");

            migrationBuilder.CreateIndex(
                name: "idx_Name",
                table: "ValueObjects",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogActions");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpPermissionGrants");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "IndexDesc");

            migrationBuilder.DropTable(
                name: "ValueObjects");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "tbAggRoots");

            migrationBuilder.DropTable(
                name: "tbEntities");

            migrationBuilder.DropTable(
                name: "AbpAuditLogs");
        }
    }
}
