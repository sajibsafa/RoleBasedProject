using AutoMapper;
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

namespace RoleBased.Core.CQRS.StudentInfo.Command;


public record UpdateStudentInfoCommands(string regNo, VMStudentInfo studentInfo ) : IRequest<CommandResult<VMStudentInfo>>;

public class UpdateStudentInfoCommandsHandler : IRequestHandler<UpdateStudentInfoCommands, CommandResult<VMStudentInfo>>
{
    private readonly IStudentInfoRepository _StudentInfoRepository;
    //private readonly IValidator<CreateStateCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateStudentInfoCommandsHandler(IStudentInfoRepository studentInfoRepository, IMapper mapper)
    {
        _StudentInfoRepository = studentInfoRepository;
        _mapper = mapper;
    }

    
    public async Task<CommandResult<VMStudentInfo>> Handle(UpdateStudentInfoCommands request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<StudentInfos>(request.studentInfo);
        var result = await _StudentInfoRepository.UpdateAsync(request.regNo, data);
        return result switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMStudentInfo>(result, CommandResultTypeEnum.Success)
        };
    }
}

