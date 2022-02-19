using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClickPC_Backend.Models
{
    public class LineInvoice
    {
        /// <summary>
        /// Modelo de Supplier segundo a Portaria (apenas dados obrigatórios necessários)
        /// Linha de documento de venda
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // Id da linha
        public string InvoiceNo { get; set; } // Identificação única do documento de venda
        public string InvoiceDate { get; set; } // Data do documento de venda
        public string LineNumber { get; set; } // Número de linha
        public string ProductCode { get; set; } // Identificador do produto ou serviço
        public string ProductDescription { get; set; } // Descrição do produto ou serviço
        public string Quantity { get; set; } // Quantidade
        public string UnitOfMeasure { get; set; } // Unidade de medida
        public string UnitPrice { get; set; } // Preço unitário
        public string TaxPointDate { get; set; } // Data de envio da mercadoria ou prestação
        public string Description { get; set; } // Descrição da linha
        public string CreditAmount { get; set; } // Valor a débito
    }
}
