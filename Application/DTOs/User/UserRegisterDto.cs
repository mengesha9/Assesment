using System.ComponentModel.DataAnnotations;
using Assesment.Application.DTOs.Common;

namespace Assesment.Application.DTOs.User;
public class UserRegisterDto 
{

[ Required]   
  public string Name {get;set;}
  [Required]
  public string Email {get;set;}
  [Required]
  public string Password {get;set;}
}