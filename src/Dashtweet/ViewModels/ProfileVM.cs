using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dashtweet.ViewModels
{
    public class ProfileVM
    {
        [Required]
        [Display(Name = "Profile Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Tracks")]
        public string[] Tracks { get; set; }

        public bool UseDataMining { get; set; } = false;
    }
}
