using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListAPI.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticController : ControllerBase
    {
        private readonly IServiceManager _service;
        public StaticController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("GetAllTaskPriorities")]
        public async Task<IActionResult> GetAllTaskPriorities()
        {
            try
            {
                var response = await _service.StaticService.GetAllTaskPrioritiesAsync(trackChanges: false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }


        [HttpGet("GetAllTaskCategories")]
        public async Task<IActionResult> GetAllTaskCategories()
        {
            try
            { 
                var response = await _service.StaticService.GetAllTaskCategoriesAsync(trackChanges: false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
}


        [HttpGet("GetAllStatuses")]
        public async Task<IActionResult> GetAllStatuses()
        {
            try
            { 
                var response = await _service.StaticService.GetAllStatusesAsync(trackChanges: false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
}

    }
}
