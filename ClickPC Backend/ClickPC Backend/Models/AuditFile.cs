using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickPC_Backend.Models
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
    public class AuditFile
    {

        private AuditFileHeader headerField;

        private AuditFileMasterFiles masterFilesField;

        private AuditFileGeneralLedgerEntries generalLedgerEntriesField;
        public AuditFileSourceDocuments SourceDocuments { get; set; }

        /// <remarks/>
        public AuditFileHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public AuditFileMasterFiles MasterFiles
        {
            get
            {
                return this.masterFilesField;
            }
            set
            {
                this.masterFilesField = value;
            }
        }

        /// <remarks/>
        public AuditFileGeneralLedgerEntries GeneralLedgerEntries
        {
            get
            {
                return this.generalLedgerEntriesField;
            }
            set
            {
                this.generalLedgerEntriesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileHeader
    {

        private string auditFileVersionField;

        private uint companyIDField;

        private uint taxRegistrationNumberField;

        private string taxAccountingBasisField;

        private string companyNameField;

        private AuditFileHeaderCompanyAddress companyAddressField;

        private ushort fiscalYearField;

        private System.DateTime startDateField;

        private System.DateTime endDateField;

        private string currencyCodeField;

        private System.DateTime dateCreatedField;

        private string taxEntityField;

        private uint productCompanyTaxIDField;

        private byte softwareCertificateNumberField;

        private string productIDField;

        private string productVersionField;

        private uint telephoneField;

        private uint faxField;

        private string emailField;

        /// <remarks/>
        public string AuditFileVersion
        {
            get
            {
                return this.auditFileVersionField;
            }
            set
            {
                this.auditFileVersionField = value;
            }
        }

        /// <remarks/>
        public uint CompanyID
        {
            get
            {
                return this.companyIDField;
            }
            set
            {
                this.companyIDField = value;
            }
        }

        /// <remarks/>
        public uint TaxRegistrationNumber
        {
            get
            {
                return this.taxRegistrationNumberField;
            }
            set
            {
                this.taxRegistrationNumberField = value;
            }
        }

        /// <remarks/>
        public string TaxAccountingBasis
        {
            get
            {
                return this.taxAccountingBasisField;
            }
            set
            {
                this.taxAccountingBasisField = value;
            }
        }

        /// <remarks/>
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }

        /// <remarks/>
        public AuditFileHeaderCompanyAddress CompanyAddress
        {
            get
            {
                return this.companyAddressField;
            }
            set
            {
                this.companyAddressField = value;
            }
        }

        /// <remarks/>
        public ushort FiscalYear
        {
            get
            {
                return this.fiscalYearField;
            }
            set
            {
                this.fiscalYearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime EndDate
        {
            get
            {
                return this.endDateField;
            }
            set
            {
                this.endDateField = value;
            }
        }

        /// <remarks/>
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime DateCreated
        {
            get
            {
                return this.dateCreatedField;
            }
            set
            {
                this.dateCreatedField = value;
            }
        }

        /// <remarks/>
        public string TaxEntity
        {
            get
            {
                return this.taxEntityField;
            }
            set
            {
                this.taxEntityField = value;
            }
        }

        /// <remarks/>
        public uint ProductCompanyTaxID
        {
            get
            {
                return this.productCompanyTaxIDField;
            }
            set
            {
                this.productCompanyTaxIDField = value;
            }
        }

        /// <remarks/>
        public byte SoftwareCertificateNumber
        {
            get
            {
                return this.softwareCertificateNumberField;
            }
            set
            {
                this.softwareCertificateNumberField = value;
            }
        }

        /// <remarks/>
        public string ProductID
        {
            get
            {
                return this.productIDField;
            }
            set
            {
                this.productIDField = value;
            }
        }

        /// <remarks/>
        public string ProductVersion
        {
            get
            {
                return this.productVersionField;
            }
            set
            {
                this.productVersionField = value;
            }
        }

        /// <remarks/>
        public uint Telephone
        {
            get
            {
                return this.telephoneField;
            }
            set
            {
                this.telephoneField = value;
            }
        }

        /// <remarks/>
        public uint Fax
        {
            get
            {
                return this.faxField;
            }
            set
            {
                this.faxField = value;
            }
        }

        /// <remarks/>
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileHeaderCompanyAddress
    {

        private string addressDetailField;

        private string cityField;

        private string postalCodeField;

        private string regionField;

        private string countryField;

        /// <remarks/>
        public string AddressDetail
        {
            get
            {
                return this.addressDetailField;
            }
            set
            {
                this.addressDetailField = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public string Region
        {
            get
            {
                return this.regionField;
            }
            set
            {
                this.regionField = value;
            }
        }

        /// <remarks/>
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileMasterFiles
    {

        private AuditFileMasterFilesGeneralLedgerAccounts generalLedgerAccountsField;

        private AuditFileMasterFilesCustomer[] customerField;

        private AuditFileMasterFilesSupplier[] supplierField;

        private AuditFileMasterFilesProduct[] productField;

        /// <remarks/>
        public AuditFileMasterFilesGeneralLedgerAccounts GeneralLedgerAccounts
        {
            get
            {
                return this.generalLedgerAccountsField;
            }
            set
            {
                this.generalLedgerAccountsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Customer")]
        public AuditFileMasterFilesCustomer[] Customer
        {
            get
            {
                return this.customerField;
            }
            set
            {
                this.customerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Supplier")]
        public AuditFileMasterFilesSupplier[] Supplier
        {
            get
            {
                return this.supplierField;
            }
            set
            {
                this.supplierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Product")]
        public AuditFileMasterFilesProduct[] Product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileMasterFilesGeneralLedgerAccounts
    {

        private string taxonomyReferenceField;

        private AuditFileMasterFilesGeneralLedgerAccountsAccount[] accountField;

        /// <remarks/>
        public string TaxonomyReference
        {
            get
            {
                return this.taxonomyReferenceField;
            }
            set
            {
                this.taxonomyReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Account")]
        public AuditFileMasterFilesGeneralLedgerAccountsAccount[] Account
        {
            get
            {
                return this.accountField;
            }
            set
            {
                this.accountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileMasterFilesGeneralLedgerAccountsAccount
    {

        private string accountIDField;

        private string accountDescriptionField;

        private string openingDebitBalanceField;

        private string openingCreditBalanceField;

        private string closingDebitBalanceField;

        private string closingCreditBalanceField;

        private string groupingCategoryField;

        private string groupingCodeField;

        private string taxonomyCodeField;

        private bool taxonomyCodeFieldSpecified;

        /// <remarks/>
        public string AccountID
        {
            get
            {
                return this.accountIDField;
            }
            set
            {
                this.accountIDField = value;
            }
        }

        /// <remarks/>
        public string AccountDescription
        {
            get
            {
                return this.accountDescriptionField;
            }
            set
            {
                this.accountDescriptionField = value;
            }
        }

        /// <remarks/>
        public string OpeningDebitBalance
        {
            get
            {
                return this.openingDebitBalanceField;
            }
            set
            {
                this.openingDebitBalanceField = value;
            }
        }

        /// <remarks/>
        public string OpeningCreditBalance
        {
            get
            {
                return this.openingCreditBalanceField;
            }
            set
            {
                this.openingCreditBalanceField = value;
            }
        }

        /// <remarks/>
        public string ClosingDebitBalance
        {
            get
            {
                return this.closingDebitBalanceField;
            }
            set
            {
                this.closingDebitBalanceField = value;
            }
        }

        /// <remarks/>
        public string ClosingCreditBalance
        {
            get
            {
                return this.closingCreditBalanceField;
            }
            set
            {
                this.closingCreditBalanceField = value;
            }
        }

        /// <remarks/>
        public string GroupingCategory
        {
            get
            {
                return this.groupingCategoryField;
            }
            set
            {
                this.groupingCategoryField = value;
            }
        }

        /// <remarks/>
        public string GroupingCode
        {
            get
            {
                return this.groupingCodeField;
            }
            set
            {
                this.groupingCodeField = value;
            }
        }

        /// <remarks/>
        public string TaxonomyCode
        {
            get
            {
                return this.taxonomyCodeField;
            }
            set
            {
                this.taxonomyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TaxonomyCodeSpecified
        {
            get
            {
                return this.taxonomyCodeFieldSpecified;
            }
            set
            {
                this.taxonomyCodeFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileMasterFilesCustomer
    {

        private string customerIDField;

        private string accountIDField;

        private string customerTaxIDField;

        private string companyNameField;

        private AuditFileMasterFilesCustomerBillingAddress billingAddressField;

        private byte selfBillingIndicatorField;

        /// <remarks/>
        public string CustomerID
        {
            get
            {
                return this.customerIDField;
            }
            set
            {
                this.customerIDField = value;
            }
        }

        /// <remarks/>
        public string AccountID
        {
            get
            {
                return this.accountIDField;
            }
            set
            {
                this.accountIDField = value;
            }
        }

        /// <remarks/>
        public string CustomerTaxID
        {
            get
            {
                return this.customerTaxIDField;
            }
            set
            {
                this.customerTaxIDField = value;
            }
        }

        /// <remarks/>
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }

        /// <remarks/>
        public AuditFileMasterFilesCustomerBillingAddress BillingAddress
        {
            get
            {
                return this.billingAddressField;
            }
            set
            {
                this.billingAddressField = value;
            }
        }

        /// <remarks/>
        public byte SelfBillingIndicator
        {
            get
            {
                return this.selfBillingIndicatorField;
            }
            set
            {
                this.selfBillingIndicatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileMasterFilesCustomerBillingAddress
    {

        private string addressDetailField;

        private string cityField;

        private string postalCodeField;

        private string countryField;

        /// <remarks/>
        public string AddressDetail
        {
            get
            {
                return this.addressDetailField;
            }
            set
            {
                this.addressDetailField = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileMasterFilesSupplier
    {

        private string supplierIDField;

        private string accountIDField;

        private string supplierTaxIDField;

        private string companyNameField;

        private string contactField;

        private AuditFileMasterFilesSupplierBillingAddress billingAddressField;

        private string telephoneField;

        private bool telephoneFieldSpecified;

        private string faxField;

        private bool faxFieldSpecified;

        private string emailField;

        private byte selfBillingIndicatorField;

        /// <remarks/>
        public string SupplierID
        {
            get
            {
                return this.supplierIDField;
            }
            set
            {
                this.supplierIDField = value;
            }
        }

        /// <remarks/>
        public string AccountID
        {
            get
            {
                return this.accountIDField;
            }
            set
            {
                this.accountIDField = value;
            }
        }

        /// <remarks/>
        public string SupplierTaxID
        {
            get
            {
                return this.supplierTaxIDField;
            }
            set
            {
                this.supplierTaxIDField = value;
            }
        }

        /// <remarks/>
        public string CompanyName
        {
            get
            {
                return this.companyNameField;
            }
            set
            {
                this.companyNameField = value;
            }
        }

        /// <remarks/>
        public string Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        public AuditFileMasterFilesSupplierBillingAddress BillingAddress
        {
            get
            {
                return this.billingAddressField;
            }
            set
            {
                this.billingAddressField = value;
            }
        }

        /// <remarks/>
        public string Telephone
        {
            get
            {
                return this.telephoneField;
            }
            set
            {
                this.telephoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TelephoneSpecified
        {
            get
            {
                return this.telephoneFieldSpecified;
            }
            set
            {
                this.telephoneFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string Fax
        {
            get
            {
                return this.faxField;
            }
            set
            {
                this.faxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FaxSpecified
        {
            get
            {
                return this.faxFieldSpecified;
            }
            set
            {
                this.faxFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        public byte SelfBillingIndicator
        {
            get
            {
                return this.selfBillingIndicatorField;
            }
            set
            {
                this.selfBillingIndicatorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileMasterFilesProduct
    {
        public string ProductType { get; set; }
        public string ProductCode { get; set; }
        public string ProductGroup { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumberCode { get; set; }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileMasterFilesSupplierBillingAddress
    {

        private string addressDetailField;

        private string cityField;

        private string postalCodeField;

        private string countryField;

        /// <remarks/>
        public string AddressDetail
        {
            get
            {
                return this.addressDetailField;
            }
            set
            {
                this.addressDetailField = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileGeneralLedgerEntries
    {

        private ushort numberOfEntriesField;

        private decimal totalDebitField;

        private decimal totalCreditField;

        private AuditFileGeneralLedgerEntriesJournal[] journalField;

        /// <remarks/>
        public ushort NumberOfEntries
        {
            get
            {
                return this.numberOfEntriesField;
            }
            set
            {
                this.numberOfEntriesField = value;
            }
        }

        /// <remarks/>
        public decimal TotalDebit
        {
            get
            {
                return this.totalDebitField;
            }
            set
            {
                this.totalDebitField = value;
            }
        }

        /// <remarks/>
        public decimal TotalCredit
        {
            get
            {
                return this.totalCreditField;
            }
            set
            {
                this.totalCreditField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Journal")]
        public AuditFileGeneralLedgerEntriesJournal[] Journal
        {
            get
            {
                return this.journalField;
            }
            set
            {
                this.journalField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileGeneralLedgerEntriesJournal
    {

        private byte journalIDField;

        private string descriptionField;

        private AuditFileGeneralLedgerEntriesJournalTransaction[] transactionField;

        /// <remarks/>
        public byte JournalID
        {
            get
            {
                return this.journalIDField;
            }
            set
            {
                this.journalIDField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Transaction")]
        public AuditFileGeneralLedgerEntriesJournalTransaction[] Transaction
        {
            get
            {
                return this.transactionField;
            }
            set
            {
                this.transactionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileGeneralLedgerEntriesJournalTransaction
    {

        private string transactionIDField;

        private string periodField;

        private string transactionDateField;

        private string sourceIDField;

        private string descriptionField;

        private string docArchivalNumberField;

        private string transactionTypeField;

        private System.DateTime gLPostingDateField;

        private string customerIDField;

        private bool customerIDFieldSpecified;

        private string supplierIDField;

        private bool supplierIDFieldSpecified;

        private AuditFileGeneralLedgerEntriesJournalTransactionLines linesField;

        /// <remarks/>
        public string TransactionID
        {
            get
            {
                return this.transactionIDField;
            }
            set
            {
                this.transactionIDField = value;
            }
        }

        /// <remarks/>
        public string Period
        {
            get
            {
                return this.periodField;
            }
            set
            {
                this.periodField = value;
            }
        }

        /// <remarks/>
        public string TransactionDate
        {
            get
            {
                return this.transactionDateField;
            }
            set
            {
                this.transactionDateField = value;
            }
        }

        /// <remarks/>
        public string SourceID
        {
            get
            {
                return this.sourceIDField;
            }
            set
            {
                this.sourceIDField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string DocArchivalNumber
        {
            get
            {
                return this.docArchivalNumberField;
            }
            set
            {
                this.docArchivalNumberField = value;
            }
        }

        /// <remarks/>
        public string TransactionType
        {
            get
            {
                return this.transactionTypeField;
            }
            set
            {
                this.transactionTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime GLPostingDate
        {
            get
            {
                return this.gLPostingDateField;
            }
            set
            {
                this.gLPostingDateField = value;
            }
        }

        /// <remarks/>
        public string CustomerID
        {
            get
            {
                return this.customerIDField;
            }
            set
            {
                this.customerIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CustomerIDSpecified
        {
            get
            {
                return this.customerIDFieldSpecified;
            }
            set
            {
                this.customerIDFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string SupplierID
        {
            get
            {
                return this.supplierIDField;
            }
            set
            {
                this.supplierIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SupplierIDSpecified
        {
            get
            {
                return this.supplierIDFieldSpecified;
            }
            set
            {
                this.supplierIDFieldSpecified = value;
            }
        }

        /// <remarks/>
        public AuditFileGeneralLedgerEntriesJournalTransactionLines Lines
        {
            get
            {
                return this.linesField;
            }
            set
            {
                this.linesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileGeneralLedgerEntriesJournalTransactionLines
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CreditLine", typeof(AuditFileGeneralLedgerEntriesJournalTransactionLinesCreditLine))]
        [System.Xml.Serialization.XmlElementAttribute("DebitLine", typeof(AuditFileGeneralLedgerEntriesJournalTransactionLinesDebitLine))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileGeneralLedgerEntriesJournalTransactionLinesCreditLine
    {

        private byte recordIDField;

        private string accountIDField;

        private System.DateTime systemEntryDateField;

        private string descriptionField;

        private string creditAmountField;

        /// <remarks/>
        public byte RecordID
        {
            get
            {
                return this.recordIDField;
            }
            set
            {
                this.recordIDField = value;
            }
        }

        /// <remarks/>
        public string AccountID
        {
            get
            {
                return this.accountIDField;
            }
            set
            {
                this.accountIDField = value;
            }
        }

        /// <remarks/>
        public System.DateTime SystemEntryDate
        {
            get
            {
                return this.systemEntryDateField;
            }
            set
            {
                this.systemEntryDateField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string CreditAmount
        {
            get
            {
                return this.creditAmountField;
            }
            set
            {
                this.creditAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileGeneralLedgerEntriesJournalTransactionLinesDebitLine
    {

        private byte recordIDField;

        private string accountIDField;

        private System.DateTime systemEntryDateField;

        private string descriptionField;

        private string debitAmountField;

        /// <remarks/>
        public byte RecordID
        {
            get
            {
                return this.recordIDField;
            }
            set
            {
                this.recordIDField = value;
            }
        }

        /// <remarks/>
        public string AccountID
        {
            get
            {
                return this.accountIDField;
            }
            set
            {
                this.accountIDField = value;
            }
        }

        /// <remarks/>
        public System.DateTime SystemEntryDate
        {
            get
            {
                return this.systemEntryDateField;
            }
            set
            {
                this.systemEntryDateField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string DebitAmount
        {
            get
            {
                return this.debitAmountField;
            }
            set
            {
                this.debitAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class AuditFileSourceDocuments
    {
        public SalesInvoices SalesInvoices { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class SalesInvoices
    {
        public string NumberOfEntries { get; set; }
        public string TotalDebit { get; set; }
        public string TotalCredit { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("Invoice")]
        public Invoices[] Invoice { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class Invoices
    {
        public string InvoiceNo { get; set; }
        public string ATCUD { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public string Hash { get; set; }
        public string HashControl { get; set; }
        public string Period { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceType { get; set; }
        public SpecialRegimes SpecialRegimes { get; set; }
        public string SourceID { get; set; }
        public string SystemEntryDate { get; set; }
        public string TransactionID { get; set; }
        public string CustomerID { get; set; }
        public ShipTo ShipTo { get; set; }
        public ShipFrom ShipFrom { get; set; }
        public string MovementStartTime { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("Line")]
        public Line[] Line { get; set; }
        public DocumentTotals DocumentTotals { get; set; }
        public WithholdingTax WithholdingTax { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class SpecialRegimes
    {
        public string SelfBillingIndicator { get; set; }
        public string CashVATSchemeIndicator { get; set; }
        public string ThirdPartiesBillingIndicator { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class ShipTo
    {
        public string DeliveryDate { get; set; }
        public Address Address { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class ShipFrom
    {
        public string DeliveryDate { get; set; }
        public Address Address { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class Address
    {
        public string AddressDetail { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class WithholdingTax
    {
        public string WithholdingTaxAmount { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class Line
    {
        public string LineNumber { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public string UnitPrice { get; set; }
        public string TaxPointDate { get; set; }
        public string Description { get; set; }
        public string CreditAmount { get; set; }
        public Tax Tax { get; set; }
        public string SettlementAmount { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class Tax
    {
        public string TaxType { get; set; }
        public string TaxCountryRegion { get; set; }
        public string TaxCode { get; set; }
        public string TaxPercentage { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class DocumentStatus
    {
        public string InvoiceStatus { get; set; }
        public string InvoiceStatusDate { get; set; }
        public string SourceID { get; set; }
        public string SourceBilling { get; set; }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
    public partial class DocumentTotals
    {
        public string TaxPayable { get; set; }
        public string NetTotal { get; set; }
        public string GrossTotal { get; set; }
    }
}

