using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expense name")]
        [Required]
        public string ExpenseName { get; set; }

        [DisplayName("Expense price")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The price is not valid")]
        public int ExpensePrice { get; set; }
    }
}
