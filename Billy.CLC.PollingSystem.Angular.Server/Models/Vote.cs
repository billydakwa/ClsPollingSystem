namespace Billy.CLC.PollingSystem.Angular.Server.Models
{
    public class Vote
    {
        public Guid Id { get; set; }
        public Poll? Poll { get; set; }
        public User? User { get; set; }
        public string Option { get; set; } = string.Empty;
    }
}
