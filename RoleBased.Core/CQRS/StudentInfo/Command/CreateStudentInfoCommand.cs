using AutoMapper;
using Employee.Shared.Models;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.StudentInfo.Command;


public record CreateStudentInfoCommand(VMStudentInfo mStudentInfo) : IRequest<CommandResult<VMStudentInfo>>;

public class CreateStudentInfoCommandHandler : IRequestHandler<CreateStudentInfoCommand, CommandResult<VMStudentInfo>>
{
    private readonly IStudentInfoRepository _StudentInfoRepository;
    
    private readonly IMapper _mapper;

    public CreateStudentInfoCommandHandler(IStudentInfoRepository studentInfoRepository, IMapper mapper)
    {
        _StudentInfoRepository = studentInfoRepository;
        _mapper = mapper;
    }
    public async Task<CommandResult<VMStudentInfo>> Handle(CreateStudentInfoCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<StudentInfos>(request.mStudentInfo);
        var result = await _StudentInfoRepository.InsertAsync(data);
        return result switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMStudentInfo>(result, CommandResultTypeEnum.Success)
        };
    }
}
