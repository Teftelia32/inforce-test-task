namespace URLShortener.DTOs
{
    public class FullUrlInfoDto
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string AuthorUsername { get; set; }
        public string AuthorEmail { get; set; }
    }
}
