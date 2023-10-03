using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBased.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Infrastructure.Persistance.Configyrations
{
    public class LoginDBConfiguration:IEntityTypeConfiguration<LoginDbs>
    {
        public void Configure(EntityTypeBuilder<LoginDbs> builder)
        {
            builder.ToTable("LoginDB", schema: "Emp");
            builder.HasKey(x => x.RegNo);
            builder.HasIndex(x => x.Role);

        }
    }
}
