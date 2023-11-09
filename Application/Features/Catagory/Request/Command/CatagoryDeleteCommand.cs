using Assesment.Application.DTOs.Catagory;
using MediatR;

namespace Assesment.Application.Features.Catagory.Request.Command;

public class CatagoryDeleteCommand:IRequest<Unit>
{
    public CatagoryDeleteDto CatagoryDeleteDto{get;set;}
}
