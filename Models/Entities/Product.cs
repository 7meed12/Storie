

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Product: BaseEntity
    {
        [Required , MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        public string PictureUrl {  get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }

    }

}
