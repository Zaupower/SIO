using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClickPC_Backend.Models
{
    public class Product
    {
        /// <summary>
        /// Modelo de Produto segundo a Portaria (dados obrigatórios)
        /// Registo na tabela de produto / serviços
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // (ProductCode) identificador do id do produto
        public string ProductType { get; set; } // Indicador de produto ou serviço (se é P, S, O, E ou I)
        public string ProductGroup { get; set; } // Família do produto ou serviço
        public string ProductDescription { get; set; } // Descrição do produto ou serviço
        public string ProductNumberCode { get; set; } // Código do produto
    }
}
