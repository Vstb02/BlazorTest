using Application.EmployeeBl.Commands.CreateEmployee;
using Application.EmployeeBL.Commands.DeleteEmployee;
using Application.EmployeeBL.Commands.UpdateEmployee;
using Application.EmployeeBL.Queries.GetEmployeeList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiControllerBase
    {
        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeListVm>> GetAll()
        {
            var query = new GetEmployeeListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeDto createAgentDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createAgentDto);
            var agentId = await Mediator.Send(command);

            return Ok(agentId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateEmployeeDto updateAgentDto)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(updateAgentDto);
            var agentId = await Mediator.Send(command);

            return Ok(agentId);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteEmployeeCommand()
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
