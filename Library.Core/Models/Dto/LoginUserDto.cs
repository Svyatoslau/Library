using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models.Dto;
public class LoginUserDto
{
    public required string Nickname { get; set; }
    public required string Password { get; set; }
}
