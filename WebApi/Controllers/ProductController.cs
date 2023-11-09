

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
    


}