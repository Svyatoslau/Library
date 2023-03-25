using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services;
public interface ITokenService
{
    string CreateToken(string nickname);
}
