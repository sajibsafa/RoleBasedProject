using Employee.Shared.Models;
using MediatR;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.LoginDB.Query;


public record GetAllLoginDbQuery : IRequest<CommandResult<IEnumerable<VMLoginDB>>>;

public class GetAllLoginDbQueryHander : IRequestHandler<GetAllLoginDbQuery, CommandResult<IEnumerable<VMLoginDB>>>
{
    private readonly ILoginBDRepository _loginDbRepository;

    public GetAllLoginDbQueryHander(ILoginBDRepository loginDbRepository)
    {
        _loginDbRepository = loginDbRepository;
    }



   

    public async Task<CommandResult<IEnumerable<VMLoginDB>>> Handle(GetAllLoginDbQuery request, CancellationToken cancellationToken)
    {
        var loginInfo = await _loginDbRepository.GetAllAsync();
        return loginInfo switch
        {
            null => new CommandResult<IEnumerable<VMLoginDB>>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<IEnumerable<VMLoginDB>>(loginInfo, CommandResultTypeEnum.Success)
        };
    }
}