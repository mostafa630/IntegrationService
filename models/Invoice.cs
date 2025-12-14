using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationServices.models
{
    public class Invoice
    {
        public string InvoiceHTMLDocument { get; set; } = string.Empty;
        public Guid InvoiceId { get; set; }
        public Guid TicketId { get; set; }
        public string TicketSerial { get; set; } = string.Empty;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NumberofHours { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public decimal TotalAmountWithOutTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public Invoice(string invoiceHTMLDocument, Guid invoiceId, Guid ticketId, string ticketSerial, DateTime fromDate, DateTime toDate, int numberofHours, string plateNumber, decimal totalAmountWithOutTax, decimal taxAmount, decimal totalAmount)
        {
            InvoiceHTMLDocument = invoiceHTMLDocument;
            InvoiceId = invoiceId;
            TicketId = ticketId;
            TicketSerial = ticketSerial;
            FromDate = fromDate;
            ToDate = toDate;
            NumberofHours = numberofHours;
            PlateNumber = plateNumber;
            TotalAmountWithOutTax = totalAmountWithOutTax;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;

        }
        public Guid GetInvoiceId()
        {
            return InvoiceId;
        }
    }
}