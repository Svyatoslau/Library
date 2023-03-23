using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models;
public class User
{
    public int Id { get; set; }
    public required string Nickname { get; set; }
    public required string Password { get; set; }
    public required Role Role { get; set; }
}
