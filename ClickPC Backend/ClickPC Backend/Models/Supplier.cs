using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClickPC_Backend.Models
{
    public class Supplier: BilingAddress
    {
        /// <summary>
        /// Modelo de Supplier segundo a Portaria (dados obrigatórios)
        /// Registo na tabela de Fornecedores
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // (SupplierId) identificador único do fornecedor
        public string AccountID { get; set; } // Código da conta
        public string SupplierTaxID { get; set; } // Número de identificação fiscal do fornecedor
        public string CompanyName { get; set; } // Nome da empresa
        public string Contact { get; set; } // Nome do contacto na empresa
        public string Telephone { get; set; } // Telefone
        public string Fax { get; set; } // Fax
        public string Email { get; set; } // Endereço de correio eletrónico da empresa

        // + os dados de faturação do fornecedor
    }
}
