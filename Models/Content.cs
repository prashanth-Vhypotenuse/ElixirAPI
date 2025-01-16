namespace ElixirAPI.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? ImagePath { get; set; }
        public string? LinkText { get; set; }
        public string? LinkPath { get; set; }
        public string? LinkIcon { get; set; }
        public string? Type { get; set; }
        public int? TypeId { get; set; }
    }
}
