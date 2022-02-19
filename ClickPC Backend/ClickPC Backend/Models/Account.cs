using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClickPC_Backend.Models
{
    public class Account
    {
        /// <summary>
        /// Modelo de Account segundo a Portaria (dados obrigatórios)
        /// Registo na tabela de contas
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } // (AccountId) código da conta
        public string AccountDescription { get; set; } // Descrição da conta
        public string OpeningDebitBalance { get; set; } // Débito da conta do plano de contas
        public string OpeningCreditBalance { get; set; } // Saldo de abertura a crédito da conta do plano de contas
        public string ClosingDebitBalance { get; set; } // Saldo de encerramento a débito da conta do plano de contas
        public string ClosingCreditBalance { get; set; } // Saldo de encerramento a crédito da conta do plano de contas
        public string GroupingCategory { get; set; } // Categoria e tipo de conta (se é GR, GA, GM, AR, AA ou AM)
        public string GroupingCode { get; set; } // Hierarquia da conta

        public override string ToString()
        {
            return Id + " --- " + AccountDescription;
        }
    }
}