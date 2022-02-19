using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClickPC_Backend.Models
{
    public class Invoice
    {
        /// <summary>
        /// Modelo de Invoice segundo a Portaria (apenas dados obrigatórios necessários)
        /// Registo na tabela para documento de venda
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // (InvoiceNo) identificação única do documento de venda
        public string Period { get; set; } // Período contabilístico
        public string InvoiceDate { get; set; } // Data do documento de venda
        public string InvoiceType { get; set; } // Tipo de documento (se é FT, FS, FR, ND, etc)
        public string SourceID { get; set; } // Código do utilizador que gerou o documento
        public string SystemEntryDate { get; set; } // Data de gravação do documento
        public string TransactionID { get; set; } // Identificador da transação
        public string CustomerID { get; set; } // Identificador do cliente
        public string MovementStartTime { get; set; } // Data e hora para o início de transporte
        public string NetTotal { get; set; } // Total do documento sem impostos
    }
}
