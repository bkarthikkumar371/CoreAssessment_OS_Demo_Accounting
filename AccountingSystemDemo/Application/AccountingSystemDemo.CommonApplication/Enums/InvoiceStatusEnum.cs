using System.ComponentModel.DataAnnotations;

namespace AccountingSystemDemo.CommonApplication.Enums
{
    /// <summary>
    /// Represents the lifecycle status of an invoice.
    /// </summary>
    public enum InvoiceStatusEnum
    {
        /// <summary>
        /// Invoice has been created and submitted for approval.
        /// </summary>
        [Display(Name = "Submitted")]
        Submitted = 1,

        /// <summary>
        /// Invoice has been approved and is awaiting payment.
        /// </summary>
        [Display(Name = "Approved")]
        Approved = 2,

        /// <summary>
        /// Invoice has been rejected and will not proceed further.
        /// </summary>
        [Display(Name = "Rejected")]
        Rejected = 3,

        /// <summary>
        /// Invoice has been fully paid.
        /// </summary>
        [Display(Name = "Paid")]
        Paid = 4,
    }
}
