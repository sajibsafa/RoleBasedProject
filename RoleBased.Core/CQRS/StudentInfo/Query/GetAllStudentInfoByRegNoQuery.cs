using Employee.Shared.Models;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.StudentInfo.Query;

public record GetAllStudentInfoByRegNoQuery (String ReNo) : IRequest<CommandResult<VMStudentInfo>>;




public class GetAllStudentInfoByRegNoQueryHandler : IRequestHandler<GetAllStudentInfoByRegNoQuery, CommandResult<VMStudentInfo>>
{
    private readonly IStudentInfoRepository  _studentInfoRepository;

    public GetAllStudentInfoByRegNoQueryHandler(IStudentInfoRepository studentInfoRepository)
    {
        _studentInfoRepository = studentInfoRepository;
    }

    

    public async Task<CommandResult<VMStudentInfo>> Handle(GetAllStudentInfoByRegNoQuery request, CancellationToken cancellationToken)
    {
        var studentInfo = await _studentInfoRepository.GetByIdAsync(request.ReNo);
        return studentInfo switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMStudentInfo>(studentInfo, CommandResultTypeEnum.Success)
        };
    }
}




