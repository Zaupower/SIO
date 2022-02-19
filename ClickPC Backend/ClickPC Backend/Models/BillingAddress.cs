using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClickPC_Backend.Models
{
    public class BilingAddress
    {
        /// <summary>
        /// Modelo de BillingAddress segundo a Portaria (dados obrigatórios)
        /// Morada de faturação
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // Id da morada
        public string AddressDetail { get; set; } // Morada detalhada
        public string City { get; set; } // Localidade
        public string PostalCode { get; set; } // Código postal
        public string Country { get; set; } // País
    }
}
