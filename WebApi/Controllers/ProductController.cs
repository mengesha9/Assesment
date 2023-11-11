

using Assesment.Application.DTOs.Product;
using Assesment.Application.Features.Product.Request.command;
using Assesment.Application.Features.Product.Request.Querie;
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
    

    [HttpPatch(template:"Update")]
      public async Task<ActionResult> Update([FromBody] ProductUpdateDto request)
    {
        var response = await _mediator.Send(new ProductUpdateCommand{ProductUpdateDto = request});
        return Ok(response);
    }


    [HttpPost(template:"Update")]
      public async Task<ActionResult> Add([FromBody] ProductCreateDto ProductCreateDto )
    {
        var response = await _mediator.Send(new ProductCreateCommand{ProductCreateDto = ProductCreateDto });
        return Ok(response);
    }

    [HttpDelete(template:"Delete")]
      public async Task<ActionResult> Delete([FromBody]  ProductDeleteDto ProductDeleteDto )
    {
        var response = await _mediator.Send(new ProductDeleteCommand{ProductDeleteDto = ProductDeleteDto });
        return Ok(response);
    }


}

