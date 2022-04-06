using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TshirtOrderPlacingPortal.DTO.Models
{
   public class TShirt
    {
        public int Id { get; set; }
        public int Size_Id { get; set; }
        public int Style_Id { get; set; }
        public string Manufature_Region { get; set; }
        public string Colour { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public bool Availablity { get; set; }    
        public string Product_Image_Name { get; set; }
        public int Cost { get; set; }
        public DateTime? ProdutionAdditionDate { get; set; }
        public DateTime? ProductUpdateDate { get; set; }
    }
}
