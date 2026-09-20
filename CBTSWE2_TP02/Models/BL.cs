using System.ComponentModel.DataAnnotations;

namespace CBTSWE2_TP02.Models
{
    public class BL
    {
        public int ID { get; set; }
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome do destinatário necessário")]
        public string Consignee { get; set; } = string.Empty;
        public string Navio {  get; set; } = string.Empty;
        public List<ContainerOBJ> ContainersOBJs { get; set; } 
            = new List<ContainerOBJ>();
    }
}
