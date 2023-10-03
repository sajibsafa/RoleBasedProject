using AutoMapper;
using Employee.Shared.Models;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoleBased.Core.CQRS.LoginDB.Command;



public record UpdateLoginDbCommand(string regNo, VMLoginDB loginDb) : IRequest<CommandResult<VMLoginDB>>;

public class UpdateLoginDbCommandHandler : IRequestHandler<UpdateLoginDbCommand, CommandResult<VMLoginDB>>
{
    private readonly ILoginBDRepository _loginDbRepository;

    private readonly IMapper _mapper;

    public UpdateLoginDbCommandHandler(ILoginBDRepository loginDbRepository, IMapper mapper)
    {
        _loginDbRepository = loginDbRepository;
        _mapper = mapper;
    }

    

    public async Task<CommandResult<VMLoginDB>> Handle(UpdateLoginDbCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<LoginDbs>(request.loginDb);
        var result = await _loginDbRepository.UpdateAsync(request.regNo, data);
        return result switch
        {
            null => new CommandResult<VMLoginDB>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMLoginDB>(result, CommandResultTypeEnum.Success)
        };
    }
}
