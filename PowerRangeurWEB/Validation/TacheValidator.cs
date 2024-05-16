using FluentValidation;
using PowerRangeurAPI.API.DTOs.Tache;

namespace PowerRangeurWEB.Validation
{
    public class TacheValidator : AbstractValidator<TacheFormCreate>
    {
        public TacheValidator() 
        {
            RuleFor(t => t.NomTache)
                .NotEmpty().WithMessage("Le nom est requis")
                .MinimumLength(3).WithMessage("La taille minimale est de 3 caractères")
                .MaximumLength(256).WithMessage("La taille max est de 256 caractères");
        }
    }
}
