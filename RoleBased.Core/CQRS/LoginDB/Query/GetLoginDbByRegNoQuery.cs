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


public record GetLoginDbByRegNoQuery(String ReNo) : IRequest<CommandResult<VMLoginDB>>;




public class GetLoginDbByRegNoQueryHandler : IRequestHandler<GetLoginDbByRegNoQuery, CommandResult<VMLoginDB>>
{
    private readonly ILoginBDRepository _loginDbRepository;

    public GetLoginDbByRegNoQueryHandler(ILoginBDRepository loginDbRepository)
    {
        _loginDbRepository = loginDbRepository;
    }

    public async Task<CommandResult<VMLoginDB>> Handle(GetLoginDbByRegNoQuery request, CancellationToken cancellationToken)
    {
        var loginInfo = await _loginDbRepository.GetByIdAsync(request.ReNo);
        return loginInfo switch
        {
            null => new CommandResult<VMLoginDB>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMLoginDB>(loginInfo, CommandResultTypeEnum.Success)
        };
    }
}