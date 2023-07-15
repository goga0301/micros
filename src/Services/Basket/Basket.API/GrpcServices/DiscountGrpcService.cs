using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoClient = discountProtoServiceClient ?? throw new ArgumentNullException(nameof(discountProtoServiceClient)) ;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest{ ProductName = productName};

            return await _discountProtoClient.GetDiscountAsync(discountRequest);
        }
    }
}
