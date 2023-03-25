using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Origin;
internal class UserOrigin : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = 1,
                Nickname = "user",
                Password = "E24FECBB80B33722CDFF42A63635555F2E1EAB5AC9F7FB28BA07F61A3D29DF27:D0AB4E3D13A15CE460D6D7AD14E7DBAD"
            }
        );
    }
}
