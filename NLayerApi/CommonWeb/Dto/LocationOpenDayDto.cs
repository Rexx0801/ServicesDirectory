namespace Common.Dto
{
    public class LocationOpenDayDto
    {
        public Guid LocationOpenDayId { get; set; }
        public string WeekendDay { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
