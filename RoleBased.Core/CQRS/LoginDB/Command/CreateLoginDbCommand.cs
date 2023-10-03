using AutoMapper;
using Employee.Shared.Models;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.LoginDB.Command;

//public class CreateLoginDbCommand
//{
//}
public record CreateLoginDbCommand(VMLoginDB mLoginDB ) : IRequest<CommandResult<VMLoginDB>>;

public class CreateLoginDbCommandHandler : IRequestHandler<CreateLoginDbCommand, CommandResult<VMLoginDB>>
{
    private readonly ILoginBDRepository _loginDbRepository;

    private readonly IMapper _mapper;

    public CreateLoginDbCommandHandler(ILoginBDRepository loginDbRepository, IMapper mapper)
    {
        _loginDbRepository = loginDbRepository;
        _mapper = mapper;
    }

   

    public async Task<CommandResult<VMLoginDB>> Handle(CreateLoginDbCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<LoginDbs>(request.mLoginDB);
        var result = await _loginDbRepository.InsertAsync(data);
        return result switch
        {
            null => new CommandResult<VMLoginDB>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMLoginDB>(result, CommandResultTypeEnum.Success)
        };
    }
}

