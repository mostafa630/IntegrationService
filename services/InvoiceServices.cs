using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationServices.DataBase;
using IntegrationServices.DTOs;
using IntegrationServices.models;

namespace IntegrationServices.services
{
    public class InvoiceServices
    {
        private readonly AppDbContext _context;

        public InvoiceServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> CreateInvoice(CreateInvoiceRequestDto request)
        {
            int numberofHours = CalculateNumberOfHours(request.FromDate , request.ToDate);
            decimal totalAmount = CalculateTotalAmount(request.TotalAmountWithOutTax, request.TaxAmount);
            Invoice newInvoice = new Invoice(request.InvoiceHTMLDocument, request.InvoiceId, request.TicketId, request.TicketSerial, request.FromDate, request.ToDate, numberofHours, request.PlateNumber, request.TotalAmountWithOutTax, request.TaxAmount, totalAmount);

            // Save the invoice to the database
            _context.Invoices.Add(newInvoice);
            await _context.SaveChangesAsync();

            return newInvoice;
        }
        private int CalculateNumberOfHours(DateTime fromDate, DateTime toDate)
        {
            TimeSpan duration = toDate - fromDate;
            return (int)duration.TotalHours;
        }
        private decimal CalculateTotalAmount(decimal totalAmountWithOutTax, decimal taxAmount)
        {
            return totalAmountWithOutTax + taxAmount;
        }
    }
}