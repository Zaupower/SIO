using ClickPC_Backend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClickPC_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class FrontendController : ControllerBase
    {
        private readonly Context _context;
        private AuditFile auditFile;

        public FrontendController(Context context)
        {
            _context = context;
        }

        public class Produto : IComparable<Produto>
        {
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public string Description { get; set; }

            public int CompareTo(Produto obj)
            {
                if (Quantidade == obj.Quantidade)
                {
                    return 0;
                }
                return -Quantidade.CompareTo(obj.Quantidade);
            }
        }

        public class MesesValores
        {
            public int Mes { get; set; }
            public float Valor { get; set; }
        }

        public class Cliente : IComparable<Cliente>
        {
            public string Id { get; set; }
            public string Nome { get; set; }
            public float Valor { get; set; }

            public int CompareTo(Cliente obj)
            {
                if (Valor == obj.Valor)
                {
                    return 0;
                }
                return -Valor.CompareTo(obj.Valor);
            }
        }

        public class Fatura
        {
            public string Id { get; set; }
            public string Documento { get; set; }
            public string Cliente_ID { get; set; }
            public string Cliente { get; set; }
            public string Data { get; set; }
            public float Valor { get; set; }
        }

        #region Gestor de Vendas Part 1

        /// <summary>
        /// Devolve o valor total de vendas de um determinado ano
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Vendas/Total_Ano")]
        public string GetValorTotalDasVendas_Ano(string ano)
        {
            if (ano == null)
                return "";

            var invoices = _context.Invoice.ToListAsync().Result.FindAll(x => x.InvoiceDate.StartsWith(ano));

            float total = 0;

            foreach (var invoice in invoices)
            {
                if (invoice.Id.StartsWith("FA"))
                    total += (float)Math.Round((float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture)) * 100f) / 100f;
                if (invoice.Id.StartsWith("DEV"))
                    total -= (float)Math.Round((float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture)) * 100f) / 100f;

            }

            return total.ToString();
        }


        /// <summary>
        /// Devolve uma lista de Meses, com o mês e o valor total de vendas desse mesmo mês
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Vendas/VendasPorMes_Ano")]
        public async Task<ActionResult<IEnumerable<MesesValores>>> GetTotalDasVendasPorMes_Ano(string ano)
        {
            if (ano == null)
                return new List<MesesValores>();

            var invoices = _context.Invoice.ToListAsync().Result.FindAll(x => x.InvoiceDate.StartsWith(ano));

            List<MesesValores> mesesValores = new List<MesesValores>();

            foreach (var invoice in invoices)
            {
                MesesValores mv = mesesValores.Find(x => x.Mes == Int16.Parse(invoice.Period));
                if (mv != null)
                {
                    if (invoice.Id.StartsWith("FA"))
                        mv.Valor = (float)Math.Round((mv.Valor + float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture)) * 100f) / 100f;
                    if (invoice.Id.StartsWith("DEV"))
                        mv.Valor = (float)Math.Round((mv.Valor - float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture)) * 100f) / 100f;
                }
                else
                {
                    if (invoice.Id.StartsWith("FA"))
                        mesesValores.Add(new MesesValores { Mes = Int16.Parse(invoice.Period), Valor = (float)Math.Round(float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture) * 100f) / 100f });
                    if (invoice.Id.StartsWith("DEV"))
                        mesesValores.Add(new MesesValores { Mes = Int16.Parse(invoice.Period), Valor = -(float)Math.Round(float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture) * 100f) / 100f });
                }
            }

            return mesesValores;
        }

        /// <summary>
        /// Devolve uma lista de Faturas, com o id da fatura, o id do documento, o id e nome do cliente da fatura e o valor dessa mesma fatura
        /// </summary>
        /// <param name="ano"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Faturas/Vendas_Ano_Mes")]
        public async Task<ActionResult<IEnumerable<Fatura>>> GetFaturasDoTotalDeVendasPorAno_Mes(string ano, int mes)
        {
            if (ano == null)
                return new List<Fatura>();

            List<Invoice> invoices = null;

            if (mes != 0)
                invoices = _context.Invoice.ToListAsync().Result.FindAll(x => x.InvoiceDate.StartsWith(ano) && Int16.Parse(x.Period) == mes);
            else
                invoices = _context.Invoice.ToListAsync().Result.FindAll(x => x.InvoiceDate.StartsWith(ano));

            List<Fatura> faturas = new List<Fatura>();

            foreach (var invoice in invoices)
            {
                if (invoice.Id.StartsWith("FA"))
                    faturas.Add(new Fatura { Id = invoice.Id, Documento = invoice.Id, Cliente_ID = invoice.CustomerID, Cliente = "", Data = invoice.InvoiceDate, Valor = (float)Math.Round(float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture) * 100f) / 100f });
            }

            //descobre o Nome do Cliente através do CustomerId

            var dados_clientes = _context.Customer.ToListAsync().Result;

            foreach (var cliente in dados_clientes)
            {
                List<Fatura> f = faturas.FindAll(x => x.Cliente_ID == cliente.Id);
                if (f != null)
                {
                    foreach (var item in f)
                    {
                        item.Cliente = cliente.CompanyName;
                    }
                }
            }

            return faturas;

        }

        #endregion

        #region Gestor de Vendas Parte 2

        /// <summary>
        /// Devolve uma lista de Clientes, com o nome, id e valor total de compras desse cliente nesse ano
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Clientes/TopClientes_Ano")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetTopClientes_Ano(string ano)
        {
            if (ano == null)
                return new List<Cliente>();

            var invoices = _context.Invoice.ToListAsync().Result.FindAll(x => x.InvoiceDate.StartsWith(ano));

            List<Cliente> clientes = new List<Cliente>();

            foreach (var invoice in invoices)
            {
                Cliente c = clientes.Find(x => x.Id == invoice.CustomerID);
                if (c != null)
                {
                    if (invoice.Id.StartsWith("FA"))
                        c.Valor = (float)Math.Round((c.Valor + float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture)) * 100f) / 100f;
                    if (invoice.Id.StartsWith("DEV"))
                        c.Valor = (float)Math.Round((c.Valor - float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture)) * 100f) / 100f;
                }
                else
                {
                    if (invoice.Id.StartsWith("FA"))
                        clientes.Add(new Cliente { Id = invoice.CustomerID, Nome = "", Valor = (float)Math.Round(float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture) * 100f) / 100f });
                    if (invoice.Id.StartsWith("DEV"))
                        clientes.Add(new Cliente { Id = invoice.CustomerID, Nome = "", Valor = -(float)Math.Round(float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture) * 100f) / 100f });
                }
            }

            // descobrir o Nome do Cliente através do CustomerId (ID do cliente)

            var dados_clientes = _context.Customer.ToListAsync().Result;

            foreach (var cliente in dados_clientes)
            {
                Cliente c = clientes.Find(x => x.Id == cliente.Id);
                if (c != null)
                {
                    c.Nome = cliente.CompanyName;
                }
            }

            clientes.Sort();

            return clientes;
        }

        /// <summary>
        /// Devolve uma lista de Faturas, com o id da fatura, a data da fatura, o id e nome do cliente e o valor dessa fatura
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Faturas/Clientes_Nome_Ano")]
        public async Task<ActionResult<IEnumerable<Fatura>>> GetFaturaDoCliente_Nome_Ano(string nome, string ano)
        {
            if (ano == "")
                return new List<Fatura>();

            var clientes = _context.Customer.ToListAsync().Result.FindAll(x => x.CompanyName == nome);

            List<Fatura> faturas = new List<Fatura>();

            foreach (var cliente in clientes)
            {
                var invoices = _context.Invoice.ToListAsync().Result.FindAll(x => x.InvoiceDate.StartsWith(ano) && x.CustomerID == cliente.Id);

                foreach (var invoice in invoices)
                {
                    if (invoice.Id.StartsWith("FA"))
                        faturas.Add(new Fatura { Id = invoice.Id, Cliente_ID = invoice.CustomerID, Cliente = cliente.CompanyName, Data = invoice.InvoiceDate, Valor = (float)Math.Round(float.Parse(invoice.NetTotal, System.Globalization.CultureInfo.InvariantCulture) * 100f) / 100f });
                }

            }

            return faturas;
        }

        #endregion

        #region Gestor de Compras Parte 1

        /// <summary>
        /// Devolve o valor total de despesas de um ano
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Despesas/Total_Ano")]
        public string GetValorTotalDasDespesas_Ano(string ano)
        {
            if (ano == null)
                return "";

            var transactions = _context.Transaction.ToListAsync().Result.FindAll(x => x.TransactionDate.StartsWith(ano) && x.Description.StartsWith("VFA"));

            float total = 0;

            foreach (var transaction in transactions)
            {
                total += (float)Math.Round((float.Parse(transaction.Amount, System.Globalization.CultureInfo.InvariantCulture)) * 100f) / 100f;

            }

            return total.ToString();
        }

        /// <summary>
        /// Devolve uma lista de Meses, com o mês e o valor total de despesas desse mês
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Despesas/DespesasPorMes_Ano")]
        public async Task<ActionResult<IEnumerable<MesesValores>>> GetValorTotalDasDespesasPorMes_Ano(string ano)
        {
            if (ano == null)
                return new List<MesesValores>();

            var transactions = _context.Transaction.ToListAsync().Result.FindAll(x => x.TransactionDate.StartsWith(ano));

            List<MesesValores> mesesValores = new List<MesesValores>();

            foreach (var transaction in transactions)
            {
                MesesValores mv = mesesValores.Find(x => x.Mes == Int16.Parse(transaction.Period));
                if (mv != null)
                {
                    if (transaction.Description.StartsWith("VFA"))
                        mv.Valor = (float)Math.Round((mv.Valor + float.Parse(transaction.Amount, System.Globalization.CultureInfo.InvariantCulture)) * 100f) / 100f;
                }
                else
                {
                    if (transaction.Description.StartsWith("VFA"))
                        mesesValores.Add(new MesesValores { Mes = Int16.Parse(transaction.Period), Valor = (float)Math.Round(float.Parse(transaction.Amount, System.Globalization.CultureInfo.InvariantCulture) * 100f) / 100f });
                }
            }

            return mesesValores;
        }

        /// <summary>
        /// Devolve uma lista de Faturas, com o id da fatura, o id do documento e o valor dessa fatura
        /// </summary>
        /// <param name="ano"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Faturas/Despesas_Ano_Mes")]
        public async Task<ActionResult<IEnumerable<Fatura>>> GetFaturasDoTotalDeDespesas_Ano_Mes(string ano, int mes)
        {
            if (ano == null)
                return new List<Fatura>();

            List<Transaction> transactions = null;

            if (mes != 0)
                transactions = _context.Transaction.ToListAsync().Result.FindAll(x => x.TransactionDate.StartsWith(ano) && Int16.Parse(x.Period) == mes);
            else
                transactions = _context.Transaction.ToListAsync().Result.FindAll(x => x.TransactionDate.StartsWith(ano));

            List<Fatura> faturas = new List<Fatura>();

            foreach (var transaction in transactions)
            {
                if (transaction.Description.StartsWith("VFA"))
                    faturas.Add(new Fatura { Id = transaction.Id, Documento = transaction.Description, Cliente_ID = "", Cliente = "", Data = transaction.TransactionDate, Valor = (float)Math.Round(float.Parse(transaction.Amount, System.Globalization.CultureInfo.InvariantCulture) * 100f) / 100f });
            }

            return faturas;
        }

        #endregion

        #region Gestor de Compras Parte 2

        /// <summary>
        /// Devolve uma lista de Produtos, com nome e quantidade vendida, dos 5 Produtos mais vendidos desse ano
        /// </summary>
        /// <param name="ano"></param>  
        /// <returns></returns>
        [HttpGet]
        [Route("Produtos/Top5ProductosVendidos_Ano")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetTop5ProductosVendidos_Ano(string ano)
        {
            if (ano == null)
                return new List<Produto>();

            var linhas = _context.LineInvoice.ToListAsync().Result.FindAll(x => x.InvoiceNo.StartsWith("FA") && x.InvoiceDate.StartsWith(ano));

            List<Produto> produtos = new List<Produto>();

            foreach (var linha in linhas)
            {
                Produto p = produtos.Find(x => x.Nome.Contains(linha.ProductCode));
                if (p != null)
                {
                    if (linha.InvoiceNo.StartsWith("FA"))
                        p.Quantidade += Int16.Parse(linha.Quantity);
                    if (linha.InvoiceNo.StartsWith("DEV"))
                        p.Quantidade -= Int16.Parse(linha.Quantity);
                }
                else
                {
                    if (linha.InvoiceNo.StartsWith("FA"))
                        produtos.Add(new Produto { Nome = linha.ProductCode, Description = linha.Description, Quantidade = Int16.Parse(linha.Quantity) });
                    if (linha.InvoiceNo.StartsWith("DEV"))
                        produtos.Add(new Produto { Nome = linha.ProductCode, Description = linha.Description, Quantidade = -Int16.Parse(linha.Quantity) });
                }
            }

            produtos.Sort();

            if (produtos.Count >= 5)
            {

                return produtos.GetRange(0, 5);
            }
            else
            {
                return produtos.GetRange(0, produtos.Count);
            }
        }

        /// <summary>
        /// Devolve uma lista de Produtos, com nome e quantidade vendida, dos 5 Produtos mais vendidos desse ano e nesse mes
        /// </summary>
        /// <param name="ano"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Produtos/Top5ProductosVendidos_Ano_Mes")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetTop5ProductosVendidos_Ano_Mes(string ano, int mes)
        {
            if (ano == null || mes == null)
                return new List<Produto>();

            string mes_string = "" + mes;

            if (mes < 10)
            {
                mes_string = "0" + mes;
            }

            List<LineInvoice> linhas = null;

            if (mes != 0)
                linhas = _context.LineInvoice.ToListAsync().Result.FindAll(x => x.InvoiceNo.StartsWith("FA") && x.InvoiceDate.StartsWith(ano + "-" + mes_string));
            else
                linhas = _context.LineInvoice.ToListAsync().Result.FindAll(x => x.InvoiceNo.StartsWith("FA") && x.InvoiceDate.StartsWith(ano));

            List<Produto> produtos = new List<Produto>();

            foreach (var linha in linhas)
            {
                Produto p = produtos.Find(x => x.Nome.Contains(linha.ProductCode));
                if (p != null)
                {
                    if (linha.InvoiceNo.StartsWith("FA"))
                        p.Quantidade += Int16.Parse(linha.Quantity);
                    if (linha.InvoiceNo.StartsWith("DEV"))
                        p.Quantidade -= Int16.Parse(linha.Quantity);
                }
                else
                {
                    if (linha.InvoiceNo.StartsWith("FA"))
                        produtos.Add(new Produto { Nome = linha.ProductCode, Description = linha.Description, Quantidade = Int16.Parse(linha.Quantity) });
                    if (linha.InvoiceNo.StartsWith("DEV"))
                        produtos.Add(new Produto { Nome = linha.ProductCode, Description = linha.Description, Quantidade = -Int16.Parse(linha.Quantity) });
                }
            }

            produtos.Sort();

            if (produtos.Count >= 5)
            {

                return produtos.GetRange(0, 5);
            }
            else
            {
                return produtos.GetRange(0, produtos.Count);
            }
        }

        #endregion

        #region File Manipulation Region

        /// <summary>
        /// Recebe o caminho para o ficheiro SAF-T que se pretende ler e lê o ficheiro, alterando os dados da base dados
        /// </summary>
        /// <param name="filePath"></param>
        [HttpGet]
        [Route("SetFile")]
        public async void SetFile(string filePath)
        {
            ClearBD();
            ReadSaft(filePath);
        }

        private void ReadSaft(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AuditFile));

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding(1252);

            try
            {
                using (Stream reader = new FileStream(filePath, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    try
                    {
                        auditFile = (AuditFile)serializer.Deserialize(reader);
                        Console.WriteLine("Ficheiro lido com sucesso.");
                        _context.SaveChanges();
                        PreencherBD();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro ao ler ficheiro.");
                        Console.WriteLine(e);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Erro - Ficheiro não encontrado.");
            }
        }

        // Preenche as tabelas da base de dados com os dados do ficheiro SAF-T
        private void PreencherBD()
        {
            if (auditFile != null)
            {
                // adicionar Accounts
                foreach (var conta in auditFile.MasterFiles.GeneralLedgerAccounts.Account)
                {
                    Account account = new Account { Id = conta.AccountID, AccountDescription = conta.AccountDescription, OpeningDebitBalance = conta.OpeningDebitBalance, OpeningCreditBalance = conta.OpeningCreditBalance, ClosingDebitBalance = conta.ClosingDebitBalance, ClosingCreditBalance = conta.ClosingCreditBalance, GroupingCategory = conta.GroupingCategory, GroupingCode = conta.GroupingCode };
                    _context.Accounts.Add(account);
                }

                // adicionar Suppliers
                if (auditFile.MasterFiles.Supplier != null)
                    foreach (var fornecedor in auditFile.MasterFiles.Supplier)
                    {
                        Supplier supplier = new Supplier { Id = fornecedor.SupplierID, AccountID = fornecedor.AccountID, SupplierTaxID = fornecedor.SupplierTaxID, CompanyName = fornecedor.CompanyName, Contact = fornecedor.Contact, Telephone = fornecedor.Telephone, Fax = fornecedor.Fax, Email = fornecedor.Email, AddressDetail = fornecedor.BillingAddress.AddressDetail, City = fornecedor.BillingAddress.City, PostalCode = fornecedor.BillingAddress.PostalCode, Country = fornecedor.BillingAddress.Country };
                        _context.Supplier.Add(supplier);
                    }

                // adicionar Customers
                if (auditFile.MasterFiles.Customer != null)
                    foreach (var cliente in auditFile.MasterFiles.Customer)
                    {
                        Customer costumer = new Customer { Id = cliente.CustomerID, AccountID = cliente.AccountID, CustomerTaxID = cliente.CustomerTaxID, CompanyName = cliente.CompanyName, AddressDetail = cliente.BillingAddress.AddressDetail, City = cliente.BillingAddress.City, PostalCode = cliente.BillingAddress.PostalCode, Country = cliente.BillingAddress.Country };
                        _context.Customer.Add(costumer);
                    }

                // adicionar Transactions
                foreach (var journal in auditFile.GeneralLedgerEntries.Journal)
                {
                    foreach (var troca in journal.Transaction)
                    {
                        Transaction transaction = new Transaction { Id = troca.TransactionID, Period = troca.Period, TransactionDate = troca.TransactionDate, SourceID = troca.SourceID, Description = troca.Description, DocArchivalNumber = troca.DocArchivalNumber, TransactionType = troca.TransactionType, GLPostingDate = troca.GLPostingDate, CustomerID = troca.CustomerID, SupplierID = troca.SupplierID };
                        try
                        {
                            if (transaction.Description.StartsWith("VFA"))
                            {
                                transaction.AccountID = ((AuditFileGeneralLedgerEntriesJournalTransactionLinesDebitLine)troca.Lines.Items[1]).AccountID;
                                transaction.SystemEntryDate = ((AuditFileGeneralLedgerEntriesJournalTransactionLinesDebitLine)troca.Lines.Items[1]).SystemEntryDate;
                                transaction.Amount = ((AuditFileGeneralLedgerEntriesJournalTransactionLinesDebitLine)troca.Lines.Items[1]).DebitAmount;
                            }
                            else if (transaction.Description.StartsWith("FA"))
                            {
                                transaction.AccountID = ((AuditFileGeneralLedgerEntriesJournalTransactionLinesDebitLine)troca.Lines.Items[0]).AccountID;
                                transaction.SystemEntryDate = ((AuditFileGeneralLedgerEntriesJournalTransactionLinesDebitLine)troca.Lines.Items[0]).SystemEntryDate;
                                transaction.Amount = ((AuditFileGeneralLedgerEntriesJournalTransactionLinesDebitLine)troca.Lines.Items[0]).DebitAmount;
                            }
                            _context.Transaction.Add(transaction);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                // adicionar Products
                if (auditFile.MasterFiles.Product != null)
                    foreach (var produto in auditFile.MasterFiles.Product)
                    {
                        if (produto.ProductType.Contains("P"))
                        {
                            Product product = new Product { Id = produto.ProductCode, ProductType = produto.ProductType, ProductGroup = produto.ProductGroup, ProductDescription = produto.ProductDescription, ProductNumberCode = produto.ProductNumberCode };
                            _context.Product.Add(product);
                        }
                    }

                // adicionar Invoices
                if (auditFile.SourceDocuments.SalesInvoices != null)
                    foreach (var item in auditFile.SourceDocuments.SalesInvoices.Invoice)
                    {
                        Invoice invoice = new Invoice { Id = item.InvoiceNo, Period = item.Period, InvoiceDate = item.InvoiceDate, InvoiceType = item.SourceID, SourceID = item.SourceID, SystemEntryDate = item.SystemEntryDate, TransactionID = item.TransactionID, CustomerID = item.CustomerID, MovementStartTime = item.MovementStartTime, NetTotal = item.DocumentTotals.NetTotal };
                        _context.Invoice.Add(invoice);

                        foreach (var linha in item.Line)
                        {
                            LineInvoice invoiceLine = new LineInvoice { InvoiceNo = item.InvoiceNo, InvoiceDate = item.InvoiceDate, LineNumber = linha.LineNumber, ProductCode = linha.ProductCode, ProductDescription = linha.ProductDescription, Quantity = linha.Quantity, UnitOfMeasure = linha.UnitOfMeasure, UnitPrice = linha.UnitPrice, TaxPointDate = linha.TaxPointDate, Description = linha.Description, CreditAmount = linha.CreditAmount };
                            _context.LineInvoice.Add(invoiceLine);
                        }
                    }
                _context.SaveChanges();
            }
        }

        // Apaga os dados das tabelas da base de dados (limpar BD)
        private void ClearBD()
        {
            foreach (var item in _context.Accounts.ToList())
            {
                _context.Accounts.Remove(item);
                _context.SaveChanges();
            }
            foreach (var item in _context.Supplier.ToList())
            {
                _context.Supplier.Remove(item);
                _context.SaveChanges();
            }
            foreach (var item in _context.Customer.ToList())
            {
                _context.Customer.Remove(item);
                _context.SaveChanges();
            }
            foreach (var item in _context.Transaction.ToList())
            {
                _context.Transaction.Remove(item);
                _context.SaveChanges();
            }
            foreach (var item in _context.Product.ToList())
            {
                _context.Product.Remove(item);
                _context.SaveChanges();
            }
            foreach (var item in _context.Invoice.ToList())
            {
                _context.Invoice.Remove(item);
                _context.SaveChanges();
            }
            foreach (var item in _context.LineInvoice.ToList())
            {
                _context.LineInvoice.Remove(item);
                _context.SaveChanges();
            }
        }

        #endregion

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}
