using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TshirtOrderPlacingPortal.DTO.Models
{
    public class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

    }
    public class FilesRetrieve
    {
      
        public string FileName { get; set; }
        public string ImageUrl { get; set; }

    }
}
