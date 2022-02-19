using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClickPC_Backend.Models
{
    public class Customer: BilingAddress
    {
        /// <summary>
        /// Modelo de Customer segundo a Portaria (dados obrigatórios)
        /// Registo na tabela de clientes
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // (CustomerId) identificador único do cliente
        public string AccountID { get; set; } // Código da conta
        public string CustomerTaxID { get; set; } // Número de identificação fiscal do cliente
        public string CompanyName { get; set; } // Nome da empresa
        
        // + os dados de faturação do cliente 
    }
}
