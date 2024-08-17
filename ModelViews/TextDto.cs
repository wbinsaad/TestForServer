namespace TestForServer.ModelViews
{
    public class TextDto
    {
        public Guid Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string sender { get; set; } = string.Empty;
        public string recipients { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;


        public string altitude { get; set; } = string.Empty;
        public string latitude { get; set; } = string.Empty;
        public string longitude { get; set; } = string.Empty;


        public DateTime CreateDate { get; set; }
        public string IPAddress { get; set; } = string.Empty;
    }
}
