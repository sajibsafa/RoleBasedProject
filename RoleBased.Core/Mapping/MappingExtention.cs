
using AutoMapper;
using RoleBased.Model;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.Mapping;

public class MappingExtention:Profile
{
    public MappingExtention()
    {
        CreateMap<VMLoginDB, LoginDbs>().ReverseMap();
        CreateMap<VMStudentInfo, StudentInfos>().ReverseMap();

        //CreateMap<VMEmployee, Employees>().ReverseMap()
        //     .ForMember(x => x.CountryName, x => x.MapFrom(x => x.Countries != null ? x.Countries.CountryName : ""))
        // .ForMember(x => x.StateName, x => x.MapFrom(x => x.States != null ? x.States.StateName : ""));
        //CreateMap<VMCountries, Countries>().ReverseMap();
        //CreateMap<VMState,States>().ReverseMap()
        //    .ForMember(x=>x.CountryName, x=>x.MapFrom(x=>x.Countries !=null? x.Countries.CountryName:""));
    }

}
