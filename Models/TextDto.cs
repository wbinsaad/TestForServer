namespace TestForServer.Models
{
    public class TextDto
    {
        public Guid Id { get; set; }

        public string name { get; set; }
        public string sender { get; set; }
        public string recipients { get; set; }
        public string content { get; set; }
        public string message { get; set; }
    }
}
