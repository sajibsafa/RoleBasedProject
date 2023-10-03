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
    public class StudentInfoConfiguration: IEntityTypeConfiguration<StudentInfos>
    {
        public void Configure(EntityTypeBuilder<StudentInfos> builder)
        {
            builder.ToTable("StudentInfo", schema: "Emp");
            builder.HasKey(x => x.RegNo);
            builder.HasIndex(x => x.Name);
           
        }
    }
}
