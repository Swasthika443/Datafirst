using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DFA_KT.Models;

public partial class Trainee
{
    [Key]
    public int Tid { get; set; }

    [Required(ErrorMessage = "Enter the Trainee Name")]
     public string? Name { get; set; }

    [Range(21, 45, ErrorMessage = "Not Eligible")] public int? Tage { get; set; }
}
