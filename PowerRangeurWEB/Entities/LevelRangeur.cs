namespace PowerRangeurWEB.Entities
{
    public partial class LevelRangeur
    {
        public int IdLevelRangeur { get; set; } = 1;
        public string NomLevelRangeur { get; set; } = "Apprenti";
        public ICollection<User>? Users { get; set; }
    }
}
