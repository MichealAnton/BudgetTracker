using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        // [Range(1,int.MaxValue,ErrorMessage ="Please select a category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int UserId {  get; set; }
        public User User { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0")]
        public double TransactionValue { get; set; }

        //[Column(TypeName = "nvarchar(75)")]
        public string? Notes { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;


    }
}
