using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PowerRangeurWEB.Entities
{
    public partial class Tache
    {
        public int IdTache { get; set; }
        public required string NomTache { get; set; }
        public int Statut { get; set; } = 0;
        public required int PrioriteTaches { get; set; } = 0;
        public required string Recurrence { get; set; } = "Non";
        public string? Description { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public DateTime DateEcheance { get; set; }
        public ICollection<User>? Users { get; set; }

        public ICollection<Mission>? Missions { get; set; }

        public BonusMalus? PointBonusMalus { get; set; }

    }
}
