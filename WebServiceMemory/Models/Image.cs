using System;
using System.Collections.Generic;

#nullable disable

namespace WebServiceMemory.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image1 { get; set; }
        public bool? IsBack { get; set; }
        public string Theme { get; set; }
    }
}
