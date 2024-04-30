using System.Reflection;

namespace PowerRangeurWEB.Entities
{
    public partial class User
    {
        public int IdUser { get; set; }
        public required string PseudoUser { get; set; }
        public string? Role { get; set; } = "Standard";
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string? Email { get; set; }

        public int? Telephone { get; set; }
        public required string Password { get; set; }

        public DateTime DateDerniereConnexion { get; set; }
        public ICollection<Tache>? Taches { get; set; }

        public ICollection<Mission>? Missions { get; set; }

        public int Score { get; set; }

        public LevelRangeur? LevelRangeur { get; set; }
    }
}
