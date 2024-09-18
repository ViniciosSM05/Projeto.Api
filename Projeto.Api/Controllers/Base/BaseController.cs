using Microsoft.AspNetCore.Mvc;
using Projeto.Api.DTO;

namespace Projeto.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected ActionResult<ResultDataDTO<TData>> Execute<TData>(Func<TData> action)
        {
            var response = new ResultDataDTO<TData>();
            try
            {
                response.SetData(action());
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                return BadRequest(response);
            }
        }

        protected ActionResult<ResultDTO> Execute(Action action)
        {
            var response = new ResultDTO();
            try
            {
                action();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.SetError(ex);
                return BadRequest(response);
            }
        }
    }
}
