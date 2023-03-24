using Library.Core.Models;
using Library.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services;
public interface IBookService : IService<Book>
{
    Task<Book> GetByIsbnAsync(string isbn);
}
