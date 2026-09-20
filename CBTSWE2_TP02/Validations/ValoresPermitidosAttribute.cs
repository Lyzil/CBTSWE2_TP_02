using System.ComponentModel.DataAnnotations;

namespace CBTSWE2_TP02.Validations
{

    //classe de validação criada para lidar com tamanhos de container permitidos,
    //pois a validação [Range(20, 40)] não funcionou como esperado. - Luiz G.

    public class ValoresPermitidosAttribute : ValidationAttribute
    {
        private readonly int[] valores;
        public ValoresPermitidosAttribute( params int[] valores)
        {
            this.valores = valores;
        }
        protected override ValidationResult? IsValid(
            object? value, 
            ValidationContext validationContext)
        {
            int tamanho = (int)value!;

            foreach(var val in valores)
            {
                if (tamanho == val)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult($"Tamanho deve ser {string.Join(" ou ", valores)}");
        }
    }
}
