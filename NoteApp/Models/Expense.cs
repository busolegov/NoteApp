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

        [DisplayName("Покупка")]
        [Required]
        public string ExpenseName { get; set; }

        [DisplayName("Сумма покупки")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Неверное значение")]
        public int ExpensePrice { get; set; }
    }
}
