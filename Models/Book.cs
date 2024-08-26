namespace CRUD_ASP.NET_CORE.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public Guid? TheLoaiId { get; set; }
    }
}
