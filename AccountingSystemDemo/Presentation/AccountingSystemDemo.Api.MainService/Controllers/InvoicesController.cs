using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CommonApplication.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AccountingSystemDemo.Api.MainService.Controllers
{
    /// <summary>
    /// API controller for invoice-related endpoints.
    /// </summary>
    [ApiController]
    [Route("api/invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceServiceClient _invoiceServiceClient;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Initializes a new instance of <see cref="InvoicesController"/>.
        /// </summary>
        /// <param name="invoiceServiceClient">Injected invoice service client.</param>
        public InvoicesController(IInvoiceServiceClient invoiceServiceClient)
        {
            _invoiceServiceClient = invoiceServiceClient;
        }

        /// <summary>
        /// Retrieves all invoices.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var data = await _invoiceServiceClient.GetAllInvoices();
            return Ok(data);
        }

        /// <summary>
        /// Retrieves a single invoice by ID.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var data = await _invoiceServiceClient.GetInvoiceById(id);
            if (data is null || data.InvoiceId == 0)
                return NotFound($"Invoice {id} not found.");
            return Ok(data);
        }

        /// <summary>
        /// Retrieves invoices by status.
        /// </summary>
        [HttpGet("status/{statusCode:int}")]
        public async Task<IActionResult> GetInvoicesByStatus(int statusCode)
        {
            if (!Enum.IsDefined(typeof(InvoiceStatusEnum), statusCode))
                return BadRequest("Invalid status code.");

            var data = await _invoiceServiceClient.GetInvoicesByStatus((InvoiceStatusEnum)statusCode);
            return Ok(data);
        }

        /// <summary>
        /// Creates a new invoice.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {
            if (createInvoiceDto is null)
                return BadRequest("Invoice payload cannot be null.");

            var invoiceDto = await _invoiceServiceClient.CreateInvoice(createInvoiceDto); ;
            if (invoiceDto is null)
                return BadRequest("Failed to create invoice.");

            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoiceDto.InvoiceId }, invoiceDto);
        }

        /// <summary>
        /// Updates the status of an invoice.
        /// </summary>
        [HttpPatch("{id:int}/status/{statusCode:int}")]
        public async Task<IActionResult> UpdateInvoiceStatus(int id, int statusCode)
        {
            if (!Enum.IsDefined(typeof(InvoiceStatusEnum), statusCode))
                return BadRequest("Invalid status code.");

            var invoiceDto = await _invoiceServiceClient.UpdateInvoiceStatus(id, (InvoiceStatusEnum)statusCode);

            if (invoiceDto is null)
                return BadRequest("Failed to update invoice.");

            return Ok(invoiceDto);
        }
    }
}