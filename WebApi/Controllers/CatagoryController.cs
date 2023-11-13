

using Assesment.Application.DTOs.Catagory;
using Assesment.Application.DTOs.Products;
using Assesment.Application.Features.Catagory.Request.Command;
using Assesment.Application.Features.Catagory.Request.Querie;
using Assesment.Application.Features.Product.Request.command;
using Assesment.Application.Features.Product.Request.Querie;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.WebAPi.Controller;
[Route(template:("api/[Controller]"))]
[ApiController]
public class CatagoryController:ControllerBase
{

    private readonly IMediator _mediator;
    public CatagoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(template:"GetAll")]

    
    public async Task<ActionResult<List<CatagoryDto>>> GetAll()
    {
        var response = await _mediator.Send(new CatagoryGetListReqeust() );
        return Ok(response);
    }

    [HttpGet(template:"GetById")]
    public async Task<ActionResult<CatagoryDto>> Get(int id)
    {
        var response = await _mediator.Send(new CatagoryGetReqeust{Id = id});
        return Ok(response);
    }

    [HttpPatch(template:"Update")]
      public async Task<ActionResult> Update([FromBody] CatagoryUpdateDto request)
    {
        var response = await _mediator.Send(new CatagoryUpdateCommand{ CatagoryUpdateDto = request});
        return Ok(response);
    }


    [HttpPost(template:"Create")]
      public async Task<ActionResult> Add([FromBody] CatagoryCreateDto request)
    {
        var response = await _mediator.Send(new CatagoryCreateCommand{CatagoryCreateDto = request });
        return Ok(response);
    }

    [HttpDelete(template:"Delete")]
      public async Task<ActionResult> Delete([FromBody]  CatagoryDeleteDto request )
    {
        var response = await _mediator.Send(new CatagoryDeleteCommand{CatagoryDeleteDto = request });
        return Ok(response);
    }


}