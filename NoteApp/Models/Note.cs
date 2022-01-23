using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Заголовок")]
        public string NoteName { get; set; }

        [DisplayName("Заметка")]
        [Required]
        public string NoteText { get; set; }

    }
}
