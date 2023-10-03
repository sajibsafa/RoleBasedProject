using Employee.Shared.Models;
using MediatR;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.StudentInfo.Query
{
    
    public record GetAllStudentInfoQuery : IRequest<CommandResult<IEnumerable<VMStudentInfo>>>;

    public class GetAllStudentInfoQueryHander : IRequestHandler<GetAllStudentInfoQuery, CommandResult<IEnumerable<VMStudentInfo>>>
    {
        private readonly IStudentInfoRepository _studentInfoRepository;

        public GetAllStudentInfoQueryHander(IStudentInfoRepository studentInfoRepository)
        {
            _studentInfoRepository = studentInfoRepository;
        }

        

        public async Task<CommandResult<IEnumerable<VMStudentInfo>>> Handle(GetAllStudentInfoQuery request, CancellationToken cancellationToken)
        {
            var studentInfo = await _studentInfoRepository.GetAllAsync();
            return studentInfo switch
            {
                null => new CommandResult<IEnumerable<VMStudentInfo>>(null, CommandResultTypeEnum.NotFound),
                _ => new CommandResult<IEnumerable<VMStudentInfo>>(studentInfo, CommandResultTypeEnum.Success)
            };
        }
    }
}
