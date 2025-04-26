using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cinema_ManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallNumber = table.Column<int>(type: "int", nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false),
                    HallType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    AgeRestriction = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bonuses = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketsCount = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sales_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Description", "Percentage" },
                values: new object[,]
                {
                    { 1, "Знижка для студентів", 10m },
                    { 2, "Знижка для пенсіонерів", 15m },
                    { 3, "Акція вихідного дня", 5m },
                    { 4, "Літня знижка", 7m },
                    { 5, "Знижка до Дня народження", 20m },
                    { 6, "Новачок у кінотеатрі", 8m },
                    { 7, "Знижка для постійних клієнтів", 12m },
                    { 8, "Знижка до 8 березня", 9m },
                    { 9, "Знижка до Чорної п'ятниці", 25m },
                    { 10, "Знижка на ранкові сеанси", 6m },
                    { 11, "Знижка на вечірні сеанси", 4m },
                    { 12, "Спеціальна пропозиція", 13m }
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "HallNumber", "HallType", "SeatsCount" },
                values: new object[,]
                {
                    { 1, 1, "Standard", 100 },
                    { 2, 2, "Standard", 120 },
                    { 3, 3, "VIP", 80 },
                    { 4, 4, "Standard", 60 },
                    { 5, 5, "VIP", 50 },
                    { 6, 6, "Standard", 90 },
                    { 7, 7, "Standard", 150 },
                    { 8, 8, "VIP", 100 },
                    { 9, 9, "Standard", 110 },
                    { 10, 10, "VIP", 70 },
                    { 11, 11, "Standard", 130 },
                    { 12, 12, "Standard", 140 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRestriction", "Description", "Director", "DurationMinutes", "Genre", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "16+", "Dream within a dream", "Christopher Nolan", 148, "Sci-Fi", 2010, "Inception" },
                    { 2, "12+", "Famous love story", "James Cameron", 195, "Drama", 1997, "Titanic" },
                    { 3, "16+", "Virtual reality fight", "Wachowski Sisters", 136, "Action", 1999, "The Matrix" },
                    { 4, "12+", "Alien world adventure", "James Cameron", 162, "Fantasy", 2009, "Avatar" },
                    { 5, "12+", "Space travel", "Christopher Nolan", 169, "Sci-Fi", 2014, "Interstellar" },
                    { 6, "18+", "Villain origin", "Todd Phillips", 122, "Drama", 2019, "Joker" },
                    { 7, "16+", "Roman arena battles", "Ridley Scott", 155, "Action", 2000, "Gladiator" },
                    { 8, "0+", "Magical kingdom", "Chris Buck", 102, "Animation", 2013, "Frozen" },
                    { 9, "0+", "Funny fairy tale", "Andrew Adamson", 90, "Animation", 2001, "Shrek" },
                    { 10, "12+", "Wizard school", "Chris Columbus", 152, "Fantasy", 2001, "Harry Potter" },
                    { 11, "12+", "Superheroes unite", "Joss Whedon", 143, "Action", 2012, "Avengers" },
                    { 12, "12+", "Friendly neighborhood hero", "Sam Raimi", 121, "Action", 2002, "Spider-Man" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "DiscountId", "PurchaseDate", "TicketsCount", "TotalAmount", "UserId" },
                values: new object[] { 10, null, new DateTime(2025, 3, 31, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 200m, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bonuses", "Email", "Name", "UserType" },
                values: new object[] { 1, 30, "ivan@gmail.com", "Іван Петренко", "Client" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "UserType" },
                values: new object[] { 2, "olena@gmail.com", "Олена Коваленко", "Client" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bonuses", "Email", "Name", "UserType" },
                values: new object[] { 3, 10, null, "Сергій Бондар", "Client" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "UserType" },
                values: new object[,]
                {
                    { 4, "maria@gmail.com", "Марія Іванова", "Admin" },
                    { 5, null, "Петро Василенко", "Client" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bonuses", "Email", "Name", "UserType" },
                values: new object[,]
                {
                    { 6, 50, "yulia@gmail.com", "Юлія Діденко", "Client" },
                    { 7, 5, null, "Артем Кравченко", "Client" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "UserType" },
                values: new object[,]
                {
                    { 8, "oksana@gmail.com", "Оксана Сидоренко", "Client" },
                    { 9, null, "Дмитро Гончар", "Client" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bonuses", "Email", "Name", "UserType" },
                values: new object[] { 10, 100, "katya@gmail.com", "Катерина Ткаченко", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "UserType" },
                values: new object[] { 11, "vlad@gmail.com", "Владислав Лисенко", "Client" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bonuses", "Email", "Name", "UserType" },
                values: new object[] { 12, 20, null, "Наталія Павленко", "Client" });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "DiscountId", "PurchaseDate", "TicketsCount", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 22, 9, 15, 0, 0, DateTimeKind.Unspecified), 2, 200m, 1 },
                    { 2, null, new DateTime(2025, 3, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 100m, 2 },
                    { 3, 2, new DateTime(2025, 3, 24, 11, 45, 0, 0, DateTimeKind.Unspecified), 3, 270m, null },
                    { 4, null, new DateTime(2025, 3, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), 2, 160m, 3 },
                    { 5, null, new DateTime(2025, 3, 26, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, 90m, 1 },
                    { 6, 3, new DateTime(2025, 3, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, 400m, 4 },
                    { 7, 2, new DateTime(2025, 3, 28, 15, 45, 0, 0, DateTimeKind.Unspecified), 2, 180m, null },
                    { 8, null, new DateTime(2025, 3, 29, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, 80m, 5 },
                    { 9, 1, new DateTime(2025, 3, 30, 17, 15, 0, 0, DateTimeKind.Unspecified), 3, 270m, 2 },
                    { 11, 3, new DateTime(2025, 4, 1, 19, 45, 0, 0, DateTimeKind.Unspecified), 5, 450m, 4 },
                    { 12, null, new DateTime(2025, 4, 2, 20, 30, 0, 0, DateTimeKind.Unspecified), 1, 100m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "DateTime", "HallId", "MovieId", "Status", "TicketPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Активний", 100m },
                    { 2, new DateTime(2025, 4, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Активний", 120m },
                    { 3, new DateTime(2025, 4, 14, 18, 30, 0, 0, DateTimeKind.Unspecified), 3, 3, "Активний", 150m },
                    { 4, new DateTime(2025, 4, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Скасований", 130m },
                    { 5, new DateTime(2025, 4, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "Активний", 110m },
                    { 6, new DateTime(2025, 4, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, "Активний", 90m },
                    { 7, new DateTime(2025, 4, 18, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 7, "Активний", 140m },
                    { 8, new DateTime(2025, 4, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, "Скасований", 200m },
                    { 9, new DateTime(2025, 4, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 9, "Активний", 160m },
                    { 10, new DateTime(2025, 4, 21, 14, 30, 0, 0, DateTimeKind.Unspecified), 5, 10, "Активний", 100m },
                    { 11, new DateTime(2025, 4, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, 11, "Активний", 170m },
                    { 12, new DateTime(2025, 4, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 12, "Активний", 180m }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Price", "SaleId", "SeatNumber", "SessionId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 100m, null, 1, 1, "Придбаний", null },
                    { 2, 100m, null, 2, 1, "Заброньований", null },
                    { 3, 120m, null, 3, 2, "Повернутий", null },
                    { 4, 120m, null, 4, 2, "Придбаний", null },
                    { 5, 150m, null, 5, 3, "Придбаний", null },
                    { 6, 150m, null, 6, 3, "Заброньований", null },
                    { 7, 130m, null, 7, 4, "Придбаний", null },
                    { 8, 110m, null, 8, 5, "Повернутий", null },
                    { 9, 90m, null, 9, 6, "Придбаний", null },
                    { 10, 140m, null, 10, 7, "Заброньований", null },
                    { 11, 200m, null, 11, 8, "Придбаний", null },
                    { 12, 160m, null, 12, 9, "Придбаний", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DiscountId",
                table: "Sales",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_HallId",
                table: "Sessions",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SaleId",
                table: "Tickets",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SessionId",
                table: "Tickets",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
