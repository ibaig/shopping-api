using System.Runtime.Serialization;

namespace Shopping.Api.Dtos
{
    public class ProductDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "price")]
        public decimal Price { get; set; }
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }
    }
}
