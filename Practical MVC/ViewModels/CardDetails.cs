using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_MVC.ViewModels
{
    public class CardDetails
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Notes { get; set; }
        public int ColumnId  { get; set; }
        public List<SelectListItem> AvailableColumns { get; set; }
    }
}
