using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models;
public class Book
{
    public int Id { get; set; }
    public required string Isbn { get; set; }
    public required string Name { get; set; }
    public string Genre { get; set; } = "";
    public string Description { get; set; } = "";
    public required string Author { get; set; }
    public DateTime? ReceiptTime { get; set; }
    public DateTime? ReturnTime { get; set; }
}
