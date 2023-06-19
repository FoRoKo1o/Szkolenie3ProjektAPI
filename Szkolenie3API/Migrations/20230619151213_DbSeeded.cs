using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Szkolenie3API.Migrations
{
    /// <inheritdoc />
    public partial class DbSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cats",
                columns: new[] { "Id", "Breed", "Color", "Description", "Weight" },
                values: new object[,]
                {
                    { 1, "Maine Coon", "Tabby", "Maine Coons are large, long-haired cats known for their friendly and sociable nature. They are often referred to as the 'gentle giants' of the cat world.", 15.0 },
                    { 2, "Siamese", "Seal Point", "Siamese cats are known for their striking blue eyes and distinctive color points on their ears, face, paws, and tail. They are highly vocal and social cats.", 8.0 },
                    { 3, "Persian", "White", "Persian cats have long, luxurious coats and a distinctive flat face. They are calm and gentle companions, often enjoying a relaxed lifestyle.", 10.0 },
                    { 4, "Abyssinian", "Ruddy", "Abyssinians are active and playful cats with short, ticked coats. They are known for their curious and outgoing personalities.", 6.0 },
                    { 5, "Scottish Fold", "Blue", "Scottish Folds have unique folded ears that give them a distinctive appearance. They are known for their sweet and gentle temperament.", 7.0 }
                });

            migrationBuilder.UpdateData(
                table: "dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Akitas are quiet, fastidious dogs. Wary of strangers and often intolerant of other animals, Akitas will gladly share their silly, affectionate side with family and friends.");

            migrationBuilder.InsertData(
                table: "dogs",
                columns: new[] { "Id", "Breed", "Color", "Description", "Weight" },
                values: new object[,]
                {
                    { 1, "Akita", "Ginger", "Akitas are quiet, fastidious dogs. Wary of strangers and often intolerant of other animals, Akitas will gladly share their silly, affectionate side with family and friends.", 30.5 },
                    { 2, "Labrador Retriever", "Yellow", "Labrador Retrievers are friendly, outgoing, and eager to please. They are intelligent and versatile, excelling in various roles, including search and rescue, therapy work, and assistance to people with disabilities.", 25.0 },
                    { 3, "Bulldog", "White", "Bulldogs are known for their sturdy build and distinctive pushed-in nose. Despite their tough appearance, they are generally gentle and great with children.", 25.0 },
                    { 4, "German Shepherd", "Tan and Black", "German Shepherds are highly intelligent and versatile dogs. They are often used as working dogs in roles such as search and rescue, police, and service dogs.", 75.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "cats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "cats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "cats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "dogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "dogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "dogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "dogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Akitas are quiet, fastidious dogs. Wary of strangers and often intolerant of other animals, Akitas will gladly share their silly, affectionate side with family and friends. They thrive on human companionship. The large, independent-thinking Akita is hardwired for protecting those they love.");
        }
    }
}
