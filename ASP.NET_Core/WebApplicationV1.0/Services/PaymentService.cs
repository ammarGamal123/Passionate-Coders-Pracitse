using Stripe;
using WebApplicationV1._0.Data;
using Product = WebApplicationV1._0.Data.Product;

namespace WebApplicationV1._0.Services
{
    public class PaymentService : IPaymentService
    {
        public readonly IConfiguration _configuration;
        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public async Task<Product> CreateOrUpdatePaymentIntentForExistingOrder(Product product)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:Secretkey"];

            var service = new PaymentIntentService();

            PaymentIntent paymentIntent;
            
            if (string.IsNullOrEmpty(product.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)product.Price * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await service.CreateAsync(options);
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)product.Price * 100,
                };
                await service.UpdateAsync(product.PaymentIntentId, options);
            }

            return product;
        }

        public Task<Product> CreateOrUpdatePaymentIntentForNewOrder(Product prodcut)
        {

            return    
        }

        public Task<ProcessResult> UpdateProdcutPaymentFailed(string paymentIntentId)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResult> UpdateProductPaymentSucceeded(string paymentIntentId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
