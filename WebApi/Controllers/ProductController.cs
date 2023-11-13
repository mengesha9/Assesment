

using Assesment.Application.DTOs.Products;
using Assesment.Application.Features.Product.Request.command;
using Assesment.Application.Features.Product.Request.Querie;
using Assesment.Application.Features.Products.Request.command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.WebAPi.Controller;
[Route(template:("api/[Controller]"))]
[ApiController]
public class ProudctController:ControllerBase
{

    private readonly IMediator _mediator;
    public ProudctController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(template:"GetAll")]

    
    public async Task<ActionResult<List<ProductDto>>> GetAll()
    {
        var response = await _mediator.Send(new ProductGetListRequest() );
        return Ok(response);
    }

    [HttpGet(template:"GetById")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        var response = await _mediator.Send(new ProductGetRequest{Id = id});
        return Ok(response);
    }

     [HttpGet(template:"Search")]
    public async Task<ActionResult<ProductDto>> Get(string  name)
    {
        var response = await _mediator.Send(new SearchProductRequest{Name = name});
        return Ok(response);
    }

    [HttpGet(template:"Book")]
    public async Task<ActionResult<ProductDto>> Book(int id,  int quantity)
    {
        var response = await _mediator.Send(new ProductBookingRequest{Id=id,Quantity=quantity});
        return Ok(response);
    }
    
    

    [HttpPatch(template:"Update")]
      public async Task<ActionResult> Update([FromBody] ProductUpdateDto request)
    {
        var response = await _mediator.Send(new ProductUpdateCommand{ProductUpdateDto = request});
        return Ok(response);
    }


    [HttpPost(template:"Create")]
      public async Task<ActionResult> Add([FromBody] ProductDto ProductCreateDto )
    {
        var response = await _mediator.Send(new ProductCreateCommand{ProductDto = ProductCreateDto });
        return Ok(response);
    }

    [HttpDelete(template:"Delete")]
      public async Task<ActionResult> Delete([FromBody]  ProductDeleteDto ProductDeleteDto )
    {
        var response = await _mediator.Send(new ProductDeleteCommand{ProductDeleteDto = ProductDeleteDto });
        return Ok(response);
    }


}

