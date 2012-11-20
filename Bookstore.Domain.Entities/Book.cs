namespace Bookstore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }

        public int AuthorId { get; set; }
        public virtual Person Author { get; set; }
    }
}
