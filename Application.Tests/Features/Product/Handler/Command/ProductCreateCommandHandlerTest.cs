


namespace Assesment.Application.Tests.Features.Product.Handler.Command;

public class ProductCreateCommandHandlerTest 
{
    private readonly Mock<IProductRepository> _mockproductRepo;
    private readonly IMapper _mapper;
    private readonly ProductCreateCommandHandler _handler;

    public ProductCreateCommandHandlerTest( 
        Mock<IProductRepository> mockproductRepo, 
        IMapper mapper ,
        ProductCreateCommandHandler handler)
    {
        _mockproductRepo = mockproductRepo;
        _mapper = mapper;
        _handler = handler; 
    }

    [Fact]
    public async Task ValidProductCreat()
    {
        var CreatDto = new ProductDto
        {
                Id = 10,
                UserId = 11;
                CategoryId = 12,
                Name = "user6",
                Description = "this good T-shirt",
                CategoryName = "Cloths"
                Pricing = 800;
                Availability = 3;
   
        };
        var response = await _handler.Handle(new ProductCreateCommand
        {
            ProductDto = CreatDto
        }
        , CancellationToken.None);

        response.ShouldNotBeNull();
        response.IsSuccess.ShouldBeTrue();


    }





   
}
