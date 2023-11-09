using Assesment.Application.DTOs.Catagory;
using MediatR;

namespace Assesment.Application.Features.Catagory.Request.Command;

public class CatagoryCreateCommand:IRequest<Unit>
{
    public CatagoryCreateDto CatagoryCreateDto{get;set;}
}