using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceMemory.Models
{
    public partial class Coordinate
    {
        public int Id { get; set; }
        public int? RowNumbers { get; set; }
        public int? ColumnNumbers { get; set; }
    }
}
