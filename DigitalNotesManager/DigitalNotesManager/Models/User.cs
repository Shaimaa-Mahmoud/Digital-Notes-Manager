using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNotesManager.Models
{
    public class User
    {
        public int UserID { get; set; }   // Primary Key
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
