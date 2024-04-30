namespace PowerRangeurWEB.Entities
{
    public partial class BonusMalus
    {
        public int IdBonusMalus { get; set; }
        public required string NomBonusMalus { get; set; }
        public required string DescriptionAttribute { get; set; }
        public int PointBonusMalus { get; set; } = 0;

        public ICollection<Tache>? Taches { get; set; }
    }
}
