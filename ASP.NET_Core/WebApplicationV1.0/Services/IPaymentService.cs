using WebApplicationV1._0.Data;

namespace WebApplicationV1._0.Services
{
    public interface IPaymentService
    {

        Task<Product> CreateOrUpdatePaymentIntentForExistingOrder(Product product);

        Task<Product> CreateOrUpdatePaymentIntentForNewOrder(Product prodcut);

        Task<ProcessResult> UpdateProductPaymentSucceeded(string paymentIntentId, int productId);

        Task<ProcessResult> UpdateProdcutPaymentFailed(string paymentIntentId);

    }
}
