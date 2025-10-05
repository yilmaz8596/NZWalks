namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId {  get; set; }
        public Guid RegionId {  get; set; }

        // Navigation Properties 
        // Each Walk is associated with one Difficulty and one Region
        // Why do we need navigation properties?
        // To easily access related data without needing to perform additional queries

        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }

    }
}
