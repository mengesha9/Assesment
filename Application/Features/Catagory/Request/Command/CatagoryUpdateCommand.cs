using Assesment.Application.DTOs.Catagory;
using MediatR;

namespace Assesment.Application.Features.Catagory.Request.Command;

public class CatagoryUpdateCommand:IRequest<Unit>
{
    public CatagoryUpdateDto CatagoryUpdateDto{get;set;}
}