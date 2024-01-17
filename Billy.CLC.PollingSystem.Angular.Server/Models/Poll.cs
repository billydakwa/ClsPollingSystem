namespace Billy.CLC.PollingSystem.Angular.Server.Models
{
    public class Poll
    {
        public Guid Id { get; set; }
        public string Pollname { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        public string Option1 { get; set; } = string.Empty;
        public string Option2 { get; set; } = string.Empty;
        public string Option3 { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}
