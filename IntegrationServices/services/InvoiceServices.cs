using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationServices.DTOs;
using IntegrationServices.models;

namespace IntegrationServices.services
{
    public static class InvoiceServices
    {
        public static Invoice CreateInvoice(CreateInvoiceRequestDto request)
        {
            int numberofHours = CalculateNumberOfHours(request.FromDate , request.ToDate);
            decimal totalAmount = CalculateTotalAmount(request.TotalAmountWithOutTax, request.TaxAmount);
            Invoice newInvoice = new Invoice(request.InvoiceHTMLDocument, request.InvoiceId, request.TicketId, request.TicketSerial, request.FromDate, request.ToDate, numberofHours, request.PlateNumber, request.TotalAmountWithOutTax, request.TaxAmount, totalAmount);
            // Additional logic to save the invoice to a database can be added here
            //ToDo : Save in Db
            return newInvoice;
        }
        private static int CalculateNumberOfHours(DateTime fromDate, DateTime toDate)
        {
            TimeSpan duration = toDate - fromDate;
            return (int)duration.TotalHours;
        }
        private static decimal CalculateTotalAmount(decimal totalAmountWithOutTax, decimal taxAmount)
        {
            return totalAmountWithOutTax + taxAmount;
        }
    }
}