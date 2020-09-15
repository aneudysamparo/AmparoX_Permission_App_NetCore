using System.Collections.Generic;
using System.Threading.Tasks;
using AmparoX.PermissionApp.Api.Dtos;
using AmparoX.PermissionApp.Api.Validators;
using AmparoX.PermissionApp.Domain.Entities;
using AmparoX.PermissionApp.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmparoX.PermissionApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _service;
        private readonly IMapper _mapper;

        public PermissionsController(IPermissionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetAll()
        {
            var items = await _service.GetAsync();
            var itemsDto = _mapper.Map<IEnumerable<Permission>, IEnumerable<PermissionDto>>(items);

            return Ok(itemsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionDto>> GetById(int id)
        {
            var permission = await _service.GetById(id);
            if(permission == null)
            {
                return NotFound();
            }
            var permissionDto = _mapper.Map<Permission, PermissionDto>(permission);

            return Ok(permissionDto);
        }



        [HttpPost("")]
        public async Task<ActionResult<PermissionDto>> Create([FromBody] SavePermissionDto createPermissionDto)
        {
            var validator = new SavePermissionDtoValidator();
            var validationResult = await validator.ValidateAsync(createPermissionDto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var permissionToCreate = _mapper.Map<SavePermissionDto, Permission>(createPermissionDto);

            var createdPermission = await _service.Create(permissionToCreate);

            var permission = await _service.GetById(createdPermission.Id);

            var permissionDto = _mapper.Map<Permission, PermissionDto>(permission);

            return Ok(permissionDto);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<PermissionDto>> UpdateArtist(int id, [FromBody] SavePermissionDto dto)
        {
            var validator = new SavePermissionDtoValidator();
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var permissionTobeEdited = await _service.GetById(id);

            if (permissionTobeEdited == null)
                return NotFound();

            var permission = _mapper.Map<SavePermissionDto, Permission>(dto);

            await _service.Update(permissionTobeEdited, permission);

            var editedPermission = await _service.GetById(id);

            var editedPermissionDto = _mapper.Map<Permission, PermissionDto>(editedPermission);

            return Ok(editedPermissionDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permission = await _service.GetById(id);

            if (permission == null)
            {
                return NotFound();
            }

            await _service.Remove(permission);

            return NoContent();
        }
    }
}
