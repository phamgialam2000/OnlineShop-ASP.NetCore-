using System.ComponentModel.DataAnnotations;

namespace ShopDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
