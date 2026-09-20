using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using CBTSWE2_TP02.Validations;

namespace CBTSWE2_TP02.Models
{
    public class ContainerOBJ
    {
        public int ID { get; set; }
        [StringLength(11, MinimumLength = 11,
            ErrorMessage = "O número do container deve possuir 11 caracteres.")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tipo necessário")]
        [RegularExpression("^(Dry|Reefer)$", ErrorMessage = "O tipo deve ser Dry ou Reefer")]
        public string Tipo { get; set; } = string.Empty;

        [ValoresPermitidos(20,40)] //  criei essa validação pq a [Range(20, 40)] não funcionou como esperado - Luiz G.
        public int Tamanho { get; set; }
        
        public int BLId { get; set; }  // FK
        [ValidateNever]
        public BL Bl { get; set; } = null!;     // Objeto
    }
}
