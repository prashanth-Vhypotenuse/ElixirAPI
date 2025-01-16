namespace ElixirAPI.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public int? OrderNumber { get; set; }
        public int? ParentId { get; set; }
        public string? Icon { get; set; }
        public int? Type { get; set; }
        public List<Menu> SubMenus { get; set; } = new List<Menu>();
    }
}
