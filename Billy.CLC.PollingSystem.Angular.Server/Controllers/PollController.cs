using Billy.CLC.PollingSystem.Angular.Server.Data;
using Billy.CLC.PollingSystem.Angular.Server.Helpers;
using Billy.CLC.PollingSystem.Angular.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Billy.CLC.PollingSystem.Angular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PollController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet("polls")]
        public ActionResult GetPolls()
        {
            //var users = _appDbContext.Users.ToList();
            var polls = _appDbContext.Polls.ToList();
            //var votes = _appDbContext.Votes.ToList();
            return Ok(polls);
        }

        [HttpGet("votes")]
        public ActionResult GetVotes()
        {         

            var query = from a in (
                from vote in _appDbContext.Votes
                join poll in _appDbContext.Polls on vote.User.Id equals poll.Id
                join user in _appDbContext.Users on vote.User.Id equals user.Id
                where poll.Option1 != null
                group vote by new { poll.Id, poll.Pollname, poll.Question } into result
                select new { result.Key.Id, result.Key.Pollname, result.Key.Question, Results = result.Count() }
             )
                        join b in (
                            from vote in _appDbContext.Votes
                            join poll in _appDbContext.Polls on vote.Poll.Id equals poll.Id
                            join user in _appDbContext.Users on vote.User.Id equals user.Id
                            where poll.Option2 != null
                            group vote by new { poll.Id, poll.Pollname, poll.Question } into result
                            select new { result.Key.Id, result.Key.Pollname, result.Key.Question, Results = result.Count() }
                         ) on a.Id equals b.Id
                        join c in (
                            from vote in _appDbContext.Votes
                            join poll in _appDbContext.Polls on vote.Poll.Id equals poll.Id
                            join user in _appDbContext.Users on vote.User.Id equals user.Id
                            where poll.Option3 != null
                            group vote by new { poll.Id, poll.Pollname, poll.Question } into result
                            select new { result.Key.Id, result.Key.Pollname, result.Key.Question, Results = result.Count() }
                         ) on a.Id equals c.Id
                        select new { a.Pollname, a.Question, A = a.Results, B = b.Results, C = c.Results };

            return Ok(query);
        }

        [HttpPost("create")]
        public async Task<ActionResult> RegisterUser([FromBody] Poll poll)
        {
                      var _poll = new Poll
            {
                Id = Guid.NewGuid(),
                Pollname = poll.Pollname,
                Question = poll.Question,
                Option1 = poll.Option1,
                Option2 = poll.Option2,
                Option3 = poll.Option3,
            };
            await _appDbContext.Polls.AddAsync(_poll);
            await _appDbContext.SaveChangesAsync();
            return Ok(_poll);
        }
    }
}
