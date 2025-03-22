namespace URLShortener.DTOs
{
    public class UrlDto
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
