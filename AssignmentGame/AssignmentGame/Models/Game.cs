using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AssignmentGame.Models
{
    public class Game
    {   [Required]
        public string Number { get; set; }
    }
}