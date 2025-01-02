using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreApp.Migrations
{
    /// <inheritdoc />
    public partial class CourseRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CoursesRecord_CourseId",
                table: "CoursesRecord",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesRecord_StudentId",
                table: "CoursesRecord",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesRecord_Courses_CourseId",
                table: "CoursesRecord",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesRecord_Students_StudentId",
                table: "CoursesRecord",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesRecord_Courses_CourseId",
                table: "CoursesRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesRecord_Students_StudentId",
                table: "CoursesRecord");

            migrationBuilder.DropIndex(
                name: "IX_CoursesRecord_CourseId",
                table: "CoursesRecord");

            migrationBuilder.DropIndex(
                name: "IX_CoursesRecord_StudentId",
                table: "CoursesRecord");
        }
    }
}
