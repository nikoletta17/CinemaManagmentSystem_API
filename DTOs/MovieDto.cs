namespace CinemaManagementSystem.DTOs
{
    /// <summary>
    /// DTO для создания нового фильма.
    /// </summary>
    public class MovieDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int DurationMinutes { get; set; }
        public int ReleaseYear { get; set; }
        public string? AgeRestriction { get; set; }
        public string Description { get; set; }
    }
}
