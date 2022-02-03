using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class ApiControllerBase : ControllerBase
    {
        private ISender _mediatr = null!;
        protected ISender Mediator => _mediatr ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}