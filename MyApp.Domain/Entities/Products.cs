using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Categories Categories { get; set; }
        public int CategoryId { get; set; }
        public Units Units { get; set; }
        public int UnitId { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int ReorderLevel { get; set; } // Minimum stock level before reordering
        public bool IsTrackInventory { get; set; } // Whether the product's inventory is tracked
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }


    }
}
