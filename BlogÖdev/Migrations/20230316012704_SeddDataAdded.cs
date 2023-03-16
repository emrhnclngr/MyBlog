using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogÖdev.Migrations
{
    public partial class SeddDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticlePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpdateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticlePicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makaleler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticlePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makaleler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Makaleler_Kullanıcılar_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "12345", "Admin" });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 2, "1234", "Member" });

            migrationBuilder.InsertData(
                table: "Makaleler",
                columns: new[] { "Id", "ArticlePicture", "AuthorId", "Content", "CreatedTime", "Title" },
                values: new object[,]
                {
                    { 1, "b687f3a3-0bd6-447a-b08e-e39e9ad976cf_1_qWiyMxttCwdDYm7YsVMiQQ", 1, "Since taking over Twitter last week, Elon Musk has found himself embroiled in multiple controversies, including his clashes with two of the most high-profile users on the site, novelist Stephen King (who has 6.9 million followers) and congresswoman Alexandria Ocasio-Cortez (who has 13.5 million followers. Both King and AOC were expressing their discontent with Musk’s plan to charge users $8 a month (originally $20 a month, before King protested) for the so-called blue check, which verified users at Twitter currently get for free.\r\n\r\nOn Tuesday, AOC tweeted “Lmao at a billionaire earnestly trying to sell people on the idea that ‘free speech’ is actually a $8/mo subscription plan,” to which Musk replied, “Your feedback is appreciated, now pay $8.” That response got more than a million likes, and sparked a debate across the site over Musk’s plan and over his willingness to alienate current blue checks (of which, full disclosure, I am one) in pursuit of more revenue for the company.\r\n\r\nMy position on this, which I wrote about this week for Fast Company, is that alienating so-called power users — high-volume, high-follower accounts —is a bad idea. The economic reality of Twitter’s business is that it is highly dependent on the content produced by these power users, who generate most of the traffic on the site. Twitter doesn’t pay these users — of whom AOC is one — anything, but it derives enormous economic value from their work. So nickel-and-diming them by requiring them to pay $8 a month for a small perk is a quintessential pennywise, pound-foolish move.\r\n\r\nOthers disagree. They think power users are well-compensated for their tweets in the form of the exposure that Twitter gives them, which creates more opportunities to build the brand and market themselves, and therefore it’s totally reasonable for Musk to try to get a little money out of them.\r\n\r\nI think that’s wrong, and I think it’s wrong in large part because it rests on a fundamentally mistaken assumption about the way people use Twitter. That assumption, which is often implicit in the way people talk about the site, is that users essentially have a set amount of time they devote to Twitter every day, and, roughly speaking, they’ll fill that amount of time with whatever content the site offers them. On this reading, tweets are largely interchangeable — as long as what’s in your feed is vaguely interesting and amusing, you’ll stick around until you’ve had your fill of tweets for the day, and and then you’ll move on.\r\n\r\nNow, if this is true, Elon Musk doesn’t have to worry that much about power users deciding to leave the site or tweeting a lot less in response to his plans (the most important of which is not charging for the blue check, but rather sharply reducing the amount of content moderation on the site). If high-volume, high-follower accounts leave, other people will take their place, and it won’t really affect how much time casual users spend on the site.\r\n\r\nThe problem is that all these assumptions are wrong. There isn’t a set amount of time that people will spend on Twitter — as anyone who uses the site regularly knows — and tweets are not largely interchangeable. On the contrary, tweets vary dramatically in terms of their effectiveness to hook and engage readers, and tweeters vary dramatically in their ability to write effective, compelling tweets.\r\n\r\nTo put it in the most banal way possible, some people are much better at tweeting than others. The more of those people Twitter has on the site, the more time users will spend on the site, and the higher its traffic will be. The fewer of them it has, the less time people will spend, and the lower its traffic will be.\r\n\r\nThis seems like it should be an obvious point. After all, the goal of any ad-driven content business isn’t just to add more viewers or listeners, but also to expand the amount of time they spend on the site. And the way to do that is to offer better — as in more engaging, more compelling — content. All of that is as true of Twitter as it is of a radio station or a TV network.\r\n\r\nBecause Twitter is a social media platform, people tend to think of it as a many-to-many business, in which the value is created by the tweets of its many millions of users. But the reality of Twitter economically is that it’s much more of a few-to-many business, with a small percentage of users producing the content that most other users read and react to. And if the the number and if the quality of those producing the content drops, so too will people’s interest in the site.\r\n\r\nIn fact, this can happen even if power users don’t actually leave the site, but instead simply spend less time tweeting, either out of frustration or because the user experience has become less enjoyable. Fewer tweets, and fewer tweets that people have invested real time in writing, will mean less interest and engagement from users, and therefore less traffic.\r\n\r\nIt is, of course, totally possible that the dopamine hits you get from tweeting will prove irresistible, and that there will be no decline in the volume of power users’ tweets, let alone an exodus of them from the site. That remains to be seen. My point is simply that such a decline, or such an exodus, would have a big impact on Twitter’s business, and it would be a bad idea for Musk to make policy in the belief that it wouldn’t.\r\n\r\n\r\n\r\n903\r\n\r\n\r\n18\r\n\r\n\r\n\r\n", new DateTime(2023, 3, 16, 4, 27, 4, 220, DateTimeKind.Local).AddTicks(2078), "Elon Musk Is Approaching Twitter As If Its Users Are Interchangeable. Is He Right?" },
                    { 3, "d9cde1ce-9ce2-43a7-846a-017b3be93c93_0_WI4tOZXOEwLBrBxH", 1, "The older I get the more I am convinced that my ancestors speak through me. This does not mean I am special. In fact it is the opposite. It means that I am only who I am because of who I belong to, who I come from.\r\n\r\nAs a writer this means I produce what we now call “work” that is sometimes odd in shape or form. Work that does things you’re not supposed to do in professional writing, work that randomly ignores narrative expectations, addresses the reader in ways you’re taught not to; work that is unnecessarily positive or negative, dour or optimistic, work that calls on itself , quotes itself, references itself, work that does not know where it is going even as it gets there. I make work that is explicit and opaque, woo-woo and cynical, earnest and sarcastic.\r\n\r\nTrying to do this work professionally means that sometimes people who pay me for my work want to tell me that I’m doing it incorrectly. And by “incorrectly” they mean “not like my limited and specific cultural experience tells me it should be done” But of course they don’t know that they mean that. This is because we live in a nation that treats money as the only real source of value. So people who have access to money believe that they must be right about most things, otherwise why would they have so much money?\r\n\r\nOver my nearly five decades, one experience I’ve seen that unites almost all oppressed people I’ve met is the experience of having the person with the most power in the room being the person who least understands what is going on, and the people who most understand what is going on have the least amount of power. Here, I would define power as the mathematical intersection of one’s ability to make things happen and the force required to make it happen. If you can make things happen with little force, you have great power. If you can make things happen but only with tremendous force, then you have lesser power. Most oppressed people I’ve met, been in community with, loved, have had the experience of having to apply tremendous force, especially in professional settings, to make things happen. We must argue, advocate, protest, complain, accuse, risk, challenge, confront, and threaten, just have our work treated with care and respect.", new DateTime(2023, 3, 16, 4, 27, 4, 221, DateTimeKind.Local).AddTicks(5429), "Liberation and Power as a Black Writer" },
                    { 2, "890d79a0-0061-4ae1-ba66-c096cb06a45c_1_EMt2IAfJBlS2ca1XoBpaTA", 2, "For most of the modern era, most people in the rich world have been poor, just like their parents and their children. Social mobility was more dream than reality. Most people were born to serve, as were their children.\r\n\r\nThe ruling minority liked to imagine that the human oxen laboring in their fields and the women who cleaned their homes and cooked their meals were happy with their lot, and professed shock and horror whenever these hereditary servers sought out ways to improve their station — whether that was by joining the industrial revolution or striking out for a colonized land and the promise of stolen estates and downtrodden servants of their own.\r\n\r\nThough the ruling minorities were small in absolute numbers, they claimed the vast majority of their nations’ wealth, and they wielded that wealth in the form of political power. That power allowed elites to turn every chance at social mobility into a mirage: factory owners and colonizers could form cartels that suppressed wages and then command militarized police armies to smash unions.\r\n\r\nIt took the two World Wars —a generation-long orgy of wealth-destruction — to weaken the power of the ruling class to such a low ebb that it could no longer drown the centuries-long dream of mobility and egalitarianism.\r\n\r\nAfter the wars, the rich countries of the world were remade.\r\n\r\nRich countries instituted ambitious social safety networks: universal secondary education, increased access to tertiary education, home ownership subsidies (in the US) and public housing (most other rich nations), free healthcare for elderly and poor people (in the US) or for everyone (other rich nations).\r\n\r\nUnions became common, and as productivity improved, wages rose. Struggles for gender justice expanded beyond a campaign for votes for wealthy white women and into universal sufferage. Civil rights struggles on racial, gender and sexual orientation lines came to the fore, and formed alliances with one another, and with anti-colonial movements in the global south.\r\n\r\nThe world changed. These were the trente glorieuses — the thirty glorious years where you could dream of a better life for your children. My father, a refugee born to refugees, went on to earn a doctorate and a comfortable middle-class living with a solid union pension. My mother, child of a working class eldest son of 10 who quit school at 12 to support his family, became the first person in her family to complete university, also earned a doctorate, and went on to a comfortable middle-class living, too. Today, they are both healthy, vigorous, and active in their mid-seventies: debt-free, owners of their home, with the guarantee of free medical care and a comfortable dotage.\r\n\r\nHistorically speaking, their lives were exceptional. They came from peasant farmers and impoverished, pogrom-haunted refugees. Historically speaking, their lot should have been largely indistinguishable from their parents, and my lot indistinguishable from theirs.", new DateTime(2023, 3, 16, 4, 27, 4, 221, DateTimeKind.Local).AddTicks(5394), "The End of the Road to Serfdom" },
                    { 4, "247b21a3-6cba-43fa-97f4-420b13dfa945_1_cCZSwnadbsvrKG3eUBaPlg", 2, "From “The Axe Forgets” — S1E5 of Andor on Disney+:\r\n\r\n(Old school Rebel device clicking )\r\n\r\nAndor: That’s an old one.\r\n\r\nNemic: Old and true. And sturdy. One of the best navigational tools ever built. Can’t be jammed or intercepted. Something breaks, you can fix it yourself.\r\n\r\nAndor: Hard to learn.\r\n\r\nNemic: Yes, but once you’ve mastered it, you’re free. We’ve grown reliant on Imperial tech, and we’ve made ourselves vulnerable. There’s a growing list of things we’ve known and forgotten, things they’ve pushed us to forget.\r\n\r\nStar Wars’ Andor is an excellent show, and I’ve been thinking about the scene quoted above the past week as Twitter has become a less-stable place. In that episode, Cassian Andor is speaking with Nemic, a true believer in the rebellion against the Empire. They were training for a raid on an Imperial base and Nemic was working on a computer navigator that would help their ship handle the escape. The navigator was decidedly Old Tech, like old cars from the ’50s and ’60s that were less complicated and easy to fix. Sure, new cars have more bells and whistles and do fancier things, but Nemic’s point was there is value to understanding the tech tool you rely on so much. When you know how to build and tinker with the tools you need, you don’t depend on someone to fix it when it breaks. You are free to use it as you like, and free to not take the easier path of an alternate tool where your use is constrained by what you’re told\r\n\r\nIn essence, it’s a simple idea. There’s a tradeoff when we outsource building and management of critical tools to others. The tools get more complicated, harder to understand, and harder to solve when things go wrong. This is not to laud simplicity per se — old cars are fixable, but those fancy computers on modern models help us guzzle less gas and keep people more safe! Rather, the model is there to help us see the trade so we can choose clearly. To know when we’ve indulged convenience too much and swung too far in one direction between freedom and control.\r\n\r\nThe purpose of this newsletter issue is to explain Mastodon, one of the emerging alternatives to Twitter. It’s had a hell of a week, nearly doubling its daily active users in the wake of the the Twitter’s sale to Elon (it had a bit over 1 million active monthly users as of the morning of Nov. 7). But Mastodon has a difficult learning curve and does not “look like” the Twitter interface we’ve gotten comfortable with over the years, and in a time when familiarity and use of a digital product can be one in the same, that matters a lot in making adoption less difficult. People are confused by what Mastodon is and by some of the explanations …", new DateTime(2023, 3, 16, 4, 27, 4, 221, DateTimeKind.Local).AddTicks(5432), "A n00b’s guide to Mastodon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Makaleler_AuthorId",
                table: "Makaleler",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleViewModel");

            migrationBuilder.DropTable(
                name: "Makaleler");

            migrationBuilder.DropTable(
                name: "UpdateViewModel");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");
        }
    }
}
