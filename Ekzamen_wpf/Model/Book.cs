using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzamen_wpf.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Jenre { get; set; }
        public Guid Author { get; set; }
        public int Num_pages { get; set; }
        public string publisher { get; set; }
        public bool seria { get; set; }
        public int cost_price { get; set; }
        public int price { get; set; }
        public int year { get; set; }

    }
}
