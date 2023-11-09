using Assesment.Application.DTOs.Catagory;
using MediatR;

namespace Assesment.Application.Features.Catagory.Request.Querie;

public class CatagoryGetReqeust:IRequest<CatagoryDto>
{
    public int Id {get;set;}

}