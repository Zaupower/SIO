using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClickPC_Backend.Models
{
    public class Transaction
    {
        /// <summary>
        /// Modelo de Transaction segundo a Portaria (dados obrigatórios)
        /// Registo da transação
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // (TransactionID) chave única do movimento contabilístico
        public string Period { get; set; } // Período contabilístico
        public string TransactionDate { get; set; } // Data do documento
        public string SourceID { get; set; } // Código do utilizador que registou o movimento
        public string Description { get; set; } // Descrição do movimento
        public string DocArchivalNumber { get; set; } // Número de arquivo do documento
        public string TransactionType { get; set; } // Tipificação do movimento contabilístico
        public DateTime GLPostingDate { get; set; } // Data do movimento contabilístico
        public string CustomerID { get; set; } // Identificador do cliente
        public string SupplierID { get; set; } // Identificador do fornecedor
        public string AccountID { get; set; } // Código da conta
        public DateTime SystemEntryDate { get; set; } // Data do registo do documento contabilístico
        public string Amount { get; set; } // (CreditAmount - Valor a crédito) ou (DebitAmount - Valor a débito)
    }
}