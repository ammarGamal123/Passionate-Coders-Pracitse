namespace WebApplicationV1._0.Data
{
    public class Product
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Sku { get; set; }

        public required decimal Price { get; set; }

        // Nullable
        public string? PaymentIntentId { get; set; }



    }
}
