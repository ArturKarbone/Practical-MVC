using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.ViewModels
{

    //todo rename to NewCard for consistency
    public class AddCard
    {
        public int Id { get; set; }
        public int BoardId => Id;
        [Required]
        public string Title { get; set; }
    }
}
