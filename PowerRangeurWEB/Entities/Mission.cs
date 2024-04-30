namespace PowerRangeurWEB.Entities
{
    public partial class Mission
    {
        public int IdMission { get; set; }
        public required string NomMission { get; set; }
        public required string DescriptionMission { get; set; }
        public DateTime? MissionDate { get; set; }
        public int BonusMission { get; set; }
        public ICollection<User>? Users { get; set; }

        public BonusMalus? BonusMalus { get; set; }
    }
}
