using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billy.CLC.PollingSystem.Angular.Server.Migrations
{
    /// <inheritdoc />
    public partial class spGetVotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetVotes
as
begin
select a.Pollname,a.Question, a.Results AS A,b.Results AS B,c.Results AS C from(
	(SELECT polls.Id,polls.Pollname,polls.Question,count(votes.id) as Results FROM votes
	INNER JOIN polls ON votes.PollId = polls.Id
	INNER JOIN users ON votes.UserId = users.Id
	where polls.Option1 is not null group by polls.Id,polls.Pollname,polls.Question) A
	JOIN
	
	(SELECT polls.Id,polls.Pollname,polls.Question,count(votes.id) as Results FROM votes
	INNER JOIN polls ON votes.PollId = polls.Id
	INNER JOIN users ON votes.UserId = users.Id
	where polls.Option2 is not null group by polls.Id,polls.Pollname,polls.Question) B
	ON A.Id = B.Id
	JOIN
	(SELECT polls.Id,polls.Pollname,polls.Question,count(votes.id) as Results FROM votes
	INNER JOIN polls ON votes.PollId = polls.Id
	INNER JOIN users ON votes.UserId = users.Id
	where polls.Option3 is not null group by polls.Id,polls.Pollname,polls.Question) C
	ON A.Id = C.Id
)
end";

			migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetVotes";

            migrationBuilder.Sql(procedure);
        }
    }
}
