using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListAPI.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TaskController(IServiceManager service)
        {
            _service = service;
        }


        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks( int userId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var response = await _service.TaskService.GetAllTasksAsync(userId, trackChanges: false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }


        [HttpGet("GetTaskById")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            try
            {
                var response = await _service.TaskService.GetTaskByIdAsync(taskId, trackChanges: false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }


        [HttpGet("GetCompletedTasks")]
        public async Task<IActionResult> GetCompletedTasks([FromQuery] int userId)
        {
            try
            {
                var response = await _service.TaskService.GetCompletedTasksAsync(userId, trackChanges: false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }

        [HttpGet("GetPendingTasks")]
        public async Task<IActionResult> GetPendingTasks([FromQuery] int userId)
        {
            try
            {
                var response = await _service.TaskService.GetPendingTasksAsync(userId, trackChanges: false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));

            }
        }

        [HttpGet("GetTasksByFilter")]
        public async Task<IActionResult> GetTasksByFilter(int userId, int? statusId = null
        , int? categoryId = null, int? priorityId = null)
        {
            try
            {
                var response = await _service.TaskService.GetTasksByFilterAsync(userId, statusId, categoryId, priorityId, trackChanges: false);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }


        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _service.TaskService.CreateTaskAsync(createTaskDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }


        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] UpdateTaskDto updateTaskDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _service.TaskService.UpdateTaskAsync(taskId, updateTaskDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }


        [HttpPut("UpdateTaskStatus")]
        public async Task<IActionResult> UpdateTaskStatus(int taskId, [FromBody] int statusId)
        {
            try
            {
                var response = await _service.TaskService.UpdateTaskStatusAsync(taskId, statusId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }


        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            try
            {
                var response = await _service.TaskService.DeleteTaskAsync(taskId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
            }
        }


    }
}
