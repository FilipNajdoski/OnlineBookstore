using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookstore.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Popularity = table.Column<bool>(nullable: false),
                    AuthorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Country = table.Column<string>(maxLength: 255, nullable: true),
                    PublisherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishers_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 350, nullable: true),
                    YearOfIssue = table.Column<DateTime>(nullable: false),
                    AuthorID = table.Column<int>(nullable: false),
                    AuthorName = table.Column<string>(maxLength: 350, nullable: true),
                    PublisherID = table.Column<int>(nullable: false),
                    PublisherName = table.Column<string>(maxLength: 350, nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 350, nullable: true),
                    NumberOfPages = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(maxLength: 150, nullable: true),
                    Price = table.Column<double>(nullable: false),
                    BookType = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Language = table.Column<string>(maxLength: 150, nullable: true),
                    Country = table.Column<string>(maxLength: 150, nullable: true),
                    Edition = table.Column<int>(nullable: false),
                    Dimensions = table.Column<string>(maxLength: 50, nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Copies = table.Column<int>(nullable: false),
                    Shipping = table.Column<string>(maxLength: 50, nullable: true),
                    PhotoURL = table.Column<string>(nullable: true),
                    SoldItems = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "eedf6e88-27ae-414f-a9c7-5f4fae390eba", "admin", "ADMIN" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e74", "0a26153b-c160-4c8a-a9b6-89ace82a943d", "editor", "EDITOR" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e75", "dac19500-dabc-453f-8046-cb96ca6bb21d", "guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "admin@onlinebookstore.com", true, false, null, "ADMIN@ONLINEBOOKSTORE.COM", "ADMIN@ONLINEBOOKSTORE.COM", "AQAAAAEAACcQAAAAEH06y7nsx97ELG+erHxCoRis07KzdxYR8PWeNqRWSdgMIsxwy62dwd3J1Qnthh8saA==", null, false, "", false, "admin@onlinebookstore.com" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AuthorId", "Name", "Popularity", "ShortDescription" },
                values: new object[,]
                {
                    { 10, null, "Dan Brown", false, "Daniel Gerhard Brown (born June 22, 1964) is an American author best known for his thriller novels, including the Robert Langdon novels Angels & Demons (2000), The Da Vinci Code (2003), The Lost Symbol (2009), Inferno (2013) and Origin (2017). His novels are treasure hunts that usually take place over a period of 24 hours.[2] They feature recurring themes of cryptography, art, and conspiracy theories. His books have been translated into 57 languages and, as of 2012, have sold over 200 million copies. Three of them, Angels & Demons, The Da Vinci Code, and Inferno, have been adapted into films." },
                    { 9, null, "Nicholas Sparks", false, "Nicholas Charles Sparks (born December 31, 1965) is an American romance novelist and screenwriter. He has published twenty novels and two non-fiction books. Several of his novels have become international bestsellers, and eleven of his romantic-drama novels have been adapted to film all with multimillion-dollar box office grosses.His novels feature stories of tragic love with happy endings." },
                    { 8, null, "Ian Fleming", false, "Ian Lancaster Fleming (28 May 1908 – 12 August 1964) was an English author, journalist and naval intelligence officer who is best known for his James Bond series of spy novels. Fleming came from a wealthy family connected to the merchant bank Robert Fleming & Co., and his father was the Member of Parliament for Henley from 1910 until his death on the Western Front in 1917. Educated at Eton, Sandhurst and, briefly, the universities of Munich and Geneva, Fleming moved through several jobs before he started writing." },
                    { 7, null, "Jeffrey Archer", false, "Jeffrey Howard Archer (born 15 April 1940) is an English novelist, former politician, convicted perjurer, and peer of the realm. Before becoming an author,Archer was a Member of Parliament(1969–1974), but did not seek re - election after a financial scandal that left him almost bankrupt.He revived his fortunes as a best - selling novelist; his books have sold around 330 million copies worldwide" },
                    { 6, null, "Paulo Coelho", false, "Paulo Coelho de Souza (born 24 August 1947) is a Brazilian lyricist and novelist, best known for his novel The Alchemist. In 2014, he uploaded his personal papers online to create a virtual Paulo Coelho Foundation" },
                    { 4, null, "J. K. Rowling", false, "Joanne Rowling CH, OBE, HonFRSE, FRCPE, FRSL, (born 31 July 1965), better known by her pen name J. K. Rowling, is a British author, film producer, television producer, screenwriter, and philanthropist. She is best known for writing the Harry Potter fantasy series,which has won multiple awards and sold more than 500 million copies, becoming the best-selling book series in history. The books are the basis of a popular film series, over which Rowling had overall approval on the scripts and was a producer on the final films. She also writes crime fiction under the name Robert Galbraith." },
                    { 3, null, "William Shakespeare", false, "William Shakespeare (bapt. 26 April 1564 – 23 April 1616) was an English poet, playwright, and actor, widely regarded as the greatest writer in the English language and the world's greatest dramatist. He is often called England's national poet and the \"Bard of Avon\" (or simply \"the Bard\"). His extant works, including collaborations, consist of some 39 plays, 154 sonnets, two long narrative poems, and a few other verses, some of uncertain authorship. His plays have been translated into every major living language and are performed more often than those of any other playwright" },
                    { 2, null, "Stephen King", true, "Stephen Edwin King (born September 21, 1947) is an American author of horror, supernatural fiction, suspense, and fantasy novels. His books have sold more than 350 million copies, many of which have been adapted into feature films, miniseries, television series, and comic books. King has published 61 novels (including seven under the pen name Richard Bachman) and six non-fiction books. He has written approximately 200 short stories, most of which have been published in book collections." },
                    { 1, null, "Agatha Christie", false, "Dame Agatha Mary Clarissa Christie, Lady Mallowan, DBE (née Miller; 15 September 1890 – 12 January 1976) was an English writer known for her 66 detective novels and 14 short story collections, particularly those revolving around fictional detectives Hercule Poirot and Miss Marple. She also wrote the world's longest-running play The Mousetrap and six romances under the pen name Mary Westmacott. In 1971, she was appointed a Dame Commander of the Order of the British Empire (DBE) for her contribution to literature" },
                    { 5, null, "Leo Tolstoy", false, "Count Lev Nikolayevich Tolstoy (9 September [O.S. 28 August] 1828 – 20 November [O.S. 7 November] 1910), usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time. He received multiple nominations for the Nobel Prize in Literature every year from 1902 to 1906, and nominations for Nobel Peace Prize in 1901, 1902 and 1910, and the fact that he never won is a major Nobel prize controversy" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 7, null, "Thrillers" },
                    { 10, null, "Uncategorised" },
                    { 9, null, "Horror" },
                    { 8, null, "General" },
                    { 6, null, "Fantasy" },
                    { 3, null, "Crime" },
                    { 4, null, "Adventure" },
                    { 2, null, "Action" },
                    { 1, null, "Fiction" },
                    { 5, null, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "Name", "PublisherId" },
                values: new object[,]
                {
                    { 9, "USA", "Houghton Mifflin Harcourt", null },
                    { 1, "Ireland", "William Morrow Paperbacks", null },
                    { 2, "USA", "Scholastic", null },
                    { 3, "Not known", "Penguin Random House", null },
                    { 4, "France", "Hachette Livre", null },
                    { 5, "USA", "HarperCollins", null },
                    { 6, "Germany", "Macmillan Publishers", null },
                    { 7, "USA", "Simon & Schuster", null },
                    { 8, "USA", "McGraw-Hill Education", null },
                    { 10, "USA", "Pearson Education", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorID", "AuthorName", "BookType", "CategoryID", "CategoryName", "Copies", "Country", "Description", "Dimensions", "Edition", "Genre", "Language", "NumberOfPages", "PhotoURL", "Price", "PublisherID", "PublisherName", "Shipping", "SoldItems", "Title", "Weight", "YearOfIssue" },
                values: new object[,]
                {
                    { 20, 1, "Agatha Christie", "Paperback", 7, "Thrillers", 70, "UK", "When Alice Ascher is murdered in Andover, Hercule Poirot is already onto the clues. Alphabetically speaking, it's one down, 25 to go. This classic mystery is now repackaged in a digest-sized edition for young adults. Reissue.", "5.82 x 8.52 x 0.94 inches", 1, "Thriller", "English", 256, "AgathaCristie_TheABCMurders.jpg", 8.4800000000000004, 7, "Simon & Schuster", "Free", 11, "The A.B.C. Murders", 0.98999999999999999, new DateTime(2006, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, "Agatha Christie", "Paperback", 7, "Thrillers", 300, "UK", "No description is available.", "5.82 x 8.52 x 0.94 inches", 1, "Thriller", "English", 256, "AgathaCristie_13_Problems.jpg", 17.48, 7, "Simon & Schuster", "Free", 11, "The Thirteen Problems", 0.34999999999999998, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, "William Shakespeare", "Paperback", 5, "Drama", 65, "UK", "Shakespeare's tragedy about Othello the Moor is presented in this freshly edited text with full explanatory notes, scene-by-scene plot summaries, an Introduction to reading Shakespeare's language, and much more. Reissue.", "4.10 x 6.70 x 1.00 inches", 1, "Drama", "English", 368, "WilliamShakespeare_Othello.jpg", 5.9800000000000004, 7, "Simon & Schuster", "Free", 18, "Othello", 0.40000000000000002, new DateTime(2003, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Stephen King", "Paperback", 9, "Horror", 20, "USA", "Once upon a time, in the haunted city of Derry (site of the classics \"It\" and \"Insomnia),\" four boys stood together and did a brave thing. Certainly a good thing, perhaps even a great thing. Something that changed them in ways they could never begin to understand. Twenty - five years later, the boys are now men with separate lives and separate troubles. But the ties endure. Each hunting season the foursome reunite in the woods of Maine. This year, a stranger stumbles into their camp, disoriented, mumbling something about lights in the sky. His incoherent ravings prove to be dis - turbingly prescient.Before long, these men will be plunged into a horrifying struggle with a creature from another world. Their only chance of survival is locked in their shared past-- and in the Dreamcatcher.", "6.51 x 9.56 x 2.01 inches", 1, "Horror", "English", 624, "StephenKing_Dreamcatcher.jpg", 13.98, 7, "Simon & Schuster", "Free", 3, "Dreamcatcher", 2.2200000000000002, new DateTime(2020, 2, 29, 23, 29, 25, 0, DateTimeKind.Unspecified) },
                    { 18, 10, "Dan Brown", "Paperback", 7, "Thrillers", 100, "USA", "#1 WORLDWIDE BESTSELLER Harvard professor of symbology Robert Langdon awakens in an Italian hospital, disoriented and with no recollection of the past thirty-six hours, including the origin of the macabre object hidden in his belongings. With a relentless female assassin trailing them through Florence, he and his resourceful doctor, Sienna Brooks, are forced to flee. Embarking on a harrowing journey, they must unravel a series of codes, which are the work of a brilliant scientist whose obsession with the end of the world is matched only by his passion for one of the most influential masterpieces ever written, Dante Alighieri's \"The Inferno.\" Dan Brown has raised the bar yet again, combining classical Italian art, history, and literature with cutting-edge science in this sumptuously entertaining thriller.", "4.28 x 7.54 x 1.33 inches", 1, "Thriller", "English", 648, "Dan-Brown_Inferno.jpg", 5.9800000000000004, 6, "Macmillan Publishers", "Free", 11, "Inferno", 0.5, new DateTime(2014, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 10, "Dan Brown", "Paperback", 7, "Thrillers", 111, "USA", "PREMIUM MASS MARKET EDITION #1 Worldwide Bestseller--More Than 80 Million Copies Sold As millions of readers around the globe have already discovered, The Da Vinci Code is a reading experience unlike any other.Simultaneously lightning - paced, intelligent,and intricately layered with remarkable research and detail, Dan Brown's novel is a thrilling masterpiece--from its opening pages to its stunning conclusion.", "4.28 x 7.54 x 1.33 inches", 2, "Thriller", "English", 608, "Dan-Brown_The-Da-Vinci-Code.jpg", 12.98, 6, "Macmillan Publishers", "Free", 12, "The Da Vinci Code", 0.48999999999999999, new DateTime(2009, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 6, "Paulo Coelho", "Paperback", 1, "Fiction", 34, "USA", "This gripping and daring novel by the author of the bestselling \"The Alchemist\" sensitively explores the sacred nature of sex and love. \"Sensual. . . for-adults - only fairytale.\"--\"Washington Post.\"", "5.32 x 8.04 x 0.77 inches", 1, "Fiction", "English", 320, "PauloCoelho_Eleven-Minutes.jpg", 12.48, 5, "HarperCollins", "Free", 8, "Eleven Minutes", 0.52000000000000002, new DateTime(2005, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, "Stephen King", "Paperback", 7, "Thrillers", 40, "USA", "Evil forces try to destroy a boy with psychic powers.", "6.44 x 9.42 x 1.46 inches", 1, "Thriller", "English", 450, "StephenKing_The-Shining.jpg", 33.479999999999997, 5, "HarperCollins", "Free", 6, "The Shining", 1.6799999999999999, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Stephen King", "Paperback", 8, "General", 150, "USA", "Stephen King's international bestselling - and highly acclaimed - novel, also a hugely successful film starring Tom Hanks", "5.12 x 7.80 x 1.22 inches", 1, "Drama", "English", 480, "StephenKing-The-Green-Mile.jpg", 23.98, 9, "Houghton Mifflin Harcourt", "Free", 4, "The Green Mile", 0.48999999999999999, new DateTime(2005, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, "Stephen King", "Paperback", 9, "Horror", 200, "USA", "Old Ralph Roberts hasn't been sleeping well lately. Every night he wakes just a little bit earlier, and pretty soon, he thinks, he won't get any sleep at all. It wouldn't be so bad, except for the strange hallucinations he's been having. Or, at least, he hopes they are hallucinations--because here in Derry, one never can tell. Part of the \"Books That Take You Anywhere You Want To Go\" Summer Reading Promotion.", "4.21 x 6.93 x 1.51 inches", 1, "Horror", "English", 663, "StephenKing_Insomnia.jpg", 12.98, 5, "HarperCollins", "Free", 5, "Insomnia", 0.69999999999999996, new DateTime(1995, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 9, "Nicholas Sparks", "Paperback", 1, "Fiction", 37, "UK", "No description is available.", "4.10 x 6.70 x 1.00 inches", 1, "Romance", "English", 463, "NicolasSparks_Every13Breath.jpg", 8.9800000000000004, 4, "Hachette Livre", "Free", 13, "Every Breath", 0.5, new DateTime(2010, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 7, "Jeffrey Archer", "Paperback", 1, "Fiction", 87, "USA", "Jeffrey Archer's mesmerizing saga of the Clifton and Barrington families continues... 1945, London. The vote in the House of Lords as to who should inherit the Barrington family fortune has ended in a tie. The Lord Chancellor's deciding vote will cast a long shadow on the lives of Harry Clifton and Giles Barrington. Harry returns to America to promote his latest novel, while his beloved Emma goes in search of the little girl who was found abandoned in her father's office on the night he was killed. When the general election is called, Giles Barrington has to defend his seat in the House of Commons and is horrified to discover who the Conservatives select to stand against him. But it is Sebastian Clifton, Harry and Emma's son, who ultimately influences his uncle's fate. In 1957, Sebastian wins a scholarship to Cambridge, and a new generation of the Clifton family marches onto the page. But after Sebastian is expelled from school, he unwittingly becomes caught up in an international art fraud involving a Rodin statue that is worth far more than the sum it raises at auction. Does he become a millionaire? Does he go to Cambridge? Is his life in danger?", "4.32 x 6.04 x 0.57 inches", 1, "Fiction", "English", 423, "ArcherJeffrey-Best-Kept-Secret.jpg", 14.48, 4, "Hachette Livre", "Free", 9, "Best Kept Secret (The Clifton Chronicles)", 0.56999999999999995, new DateTime(2014, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 8, "Ian Fleming", "Paperback", 2, "Action", 10, "UK", "The lethal SMERSH organization in Russia has targeted Agent 007 for elimination. But when James Bond allows himself to be lured to Istanbul and walks willingly into a trap, a game of cross and double-cross ensues, with Bond as both the stakes and the prize.", "5.12 x 7.72 x 0.53 inches", 1, "Action", "English", 272, "IanFleming_From-Russia-with-Love.jpg", 6.4800000000000004, 3, "Penguin Random House", "Free", 14, "From Russia with Love", 0.41999999999999998, new DateTime(2002, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 8, "Ian Fleming", "Paperback", 2, "Action", 122, "UK", "In the novel that introduced James Bond to the world, Ian Fleming's agent 007 is dispatched to a French casino in Royale-les-Eaux. His mission? Bankrupt a ruthless Russian agent who's been on a bad luck streak at the baccarat table. One of SMERSH's most deadly operatives, the man known only as ?Le Chiffre, ? has been a prime target of the British Secret Service for years. If Bond can wipe out his bankroll, Le Chiffre will likely be ?retired? by his paymasters in Moscow. But what if the cards won't cooperate? After a brutal night at the gaming tables, Bond soon finds himself dodging would-be assassins, fighting off brutal torturers, and going all-in to save the life of his beautiful female counterpart, Vesper Lynd. Taut, tense, and effortlessly stylish, Ian Fleming's inaugural James Bond adventure has all the hallmarks that made the series a touchstone for a generation of readers.", "4.32 x 6.04 x 0.57 inches", 1, "Action", "English", 486, "IanFlemming_Casino_Royale.jpg", 13.48, 3, "Penguin Random House", "Free", 15, "Casino Royale", 0.29999999999999999, new DateTime(2012, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Stephen King", "Paperback", 6, "Fantasy", 50, "", "Now a major motion picture starring Matthew McConaughey and Idris Elba. An impressive work of mythic magnitude that may turn out to be Stephen King's greatest literary achievement (The Atlanta Journal-Constitution), The Gunslinger is the first volume in the epic Dark Tower Series. A #1 national bestseller, The Gunslinger introduces readers to one of Stephen King's most powerful creations, Roland of Gilead: The Last Gunslinger. He is a haunting figure, a loner on a spellbinding journey into good and evil. In his desolate world, which mirrors our own in frightening ways, Roland tracks The Man in Black, encounters an enticing woman named Alice, and begins a friendship with the boy from New York named Jake. Inspired in part by the Robert Browning narrative poem,Childe Roland to the Dark Tower Came, The Gunslinger is a compelling whirlpool of a story that draws one irretrievable to its center ( Milwaukee Sentinel ). It is brilliant and fresh...and will leave you panting for more ( Booklist ).", "Not known", 1, "Fantasy", "English", 586, "StephenKing_The_Dark_Tower.jpg", 11.48, 2, "Scholastic", "Free", 19, "The Dark Tower I: The Gunslinger", 0.59999999999999998, new DateTime(2017, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 6, "Paulo Coelho", "Paperback", 1, "Fiction", 222, "UK", "This international bestseller about the shepherd boy Santiago who learns how to live his dreams includes an inspiring afterword by the author.", "5.36 x 8.02 x 0.56 inches", 1, "Fiction", "English", 197, "PauloCoelho_The-Alchemist.jpg", 6.9800000000000004, 1, "William Morrow Paperbacks", "Free", 16, "The Alchemist", 0.48999999999999999, new DateTime(2006, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 4, "J. K. Rowling", "Paperback", 1, "Fiction", 131, "UK", "The one that started the biggest publishing phenomenon of our time", "4.45 x 7.01 x 0.87 inches", 1, "Fiction", "English", 336, "Harry-Potter-and-the-Philosopher-s-Stone-Rowling-J-K.jpg", 9.9800000000000004, 1, "William Morrow Paperbacks", "Free", 17, "Harry Potter and the Philosopher's Stone", 0.34999999999999998, new DateTime(2004, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, "Agatha Cristie", "Paperback", 1, "Fiction", 100, "UK", "Book seed 1 Description", "12x12x20", 1, "Fiction", "English", 586, "AgathaCristie_MurderOnTheOrientExpress.jpg", 9.9900000000000002, 1, "William Morrow Paperbacks", "Free", 20, "Murder On The Orient Express", 0.48999999999999999, new DateTime(2020, 2, 29, 23, 29, 25, 0, DateTimeKind.Unspecified) },
                    { 16, 9, "Nicholas Sparks", "Paperback", 1, "Fiction", 44, "UK", "#1 bestselling author Nicholas Sparks's new novel is at once a compelling family drama and a heartrending tale of young love.Seventeen year old Veronica \"Ronnie\" Miller's life was turned upside-down when her parents divorced and her father moved from New York City to Wilmington, North Carolina. Three years later, she remains angry and alientated from her parents, especially her father...until her mother decides it would be in everyone's best interest if she spent the summer in Wilmington with him. Ronnie's father, a former concert pianist and teacher, is living a quiet life in the beach town, immersed in creating a work of art that will become the centerpiece of a local church.The tale that unfolds is an unforgettable story of love on many levels--first love, love between parents and children -- that demonstrates, as only a Nicholas Sparks novel can, the many ways that love can break our hearts...and heal them.", "4.10 x 6.70 x 1.00 inches", 1, "Romance", "English", 463, "NicolasSparks_The-Last-Song.jpg", 8.9800000000000004, 4, "Hachette Livre", "Free", 10, "The Last Song", 0.5, new DateTime(2010, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, "Stephen King", "Paperback", 9, "Horror", 230, "USA", "Now repackaged with stunning new cover art, this #1 bestseller is a chilling story set in a lonely Nevada town where the evil embedded in the landscape is awesome--but so are the forces summoned to combat it. Reissue", "4.22 x 6.86 x 1.52 inches", 1, "Horror", "English", 547, "StephenKing_Desperation.jpg", 22.98, 10, "Pearson Education", "Free", 7, "Desperation", 0.48999999999999999, new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorId",
                table: "Authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryID",
                table: "Books",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherID",
                table: "Books",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BookId",
                table: "Photos",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_PublisherId",
                table: "Publishers",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
