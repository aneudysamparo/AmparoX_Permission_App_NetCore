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
    public class PermissionTypesController : ControllerBase
    {
        private readonly IPermissionTypeService _service;
        private readonly IMapper _mapper;

        public PermissionTypesController(IPermissionTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }



        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PermissionTypeDto>>> GetAll()
        {
            var items = await _service.GetAsync();
            var itemsDto = _mapper.Map<IEnumerable<PermissionType>, IEnumerable<PermissionTypeDto>>(items);

            return Ok(itemsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionTypeDto>> GetById(int id)
        {
            var permissionType = await _service.GetById(id);
            if (permissionType == null)
            {
                return NotFound();
            }
            var permissionTypeDto = _mapper.Map<PermissionType, PermissionTypeDto>(permissionType);

            return Ok(permissionTypeDto);
        }


        [HttpPost("")]
        public async Task<ActionResult<PermissionTypeDto>> Create([FromBody] SavePermissionTypeDto dto)
        {
            var validator = new SavePermissionTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var permissionTypeToCreate = _mapper.Map<SavePermissionTypeDto, PermissionType>(dto);

            var createdPermissionType = await _service.Create(permissionTypeToCreate);

            var permissionType = await _service.GetById(createdPermissionType.Id);

            var permissionTypeDto = _mapper.Map<PermissionType, PermissionTypeDto>(permissionType);

            return Ok(permissionTypeDto);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<PermissionTypeDto>> UpdateArtist(int id, [FromBody] SavePermissionTypeDto dto)
        {
            var validator = new SavePermissionTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var permissionTobeEdited = await _service.GetById(id);

            if (permissionTobeEdited == null)
                return NotFound();

            var permissionType = _mapper.Map<SavePermissionTypeDto, PermissionType>(dto);

            await _service.Update(permissionTobeEdited, permissionType);

            var editedPermissionType = await _service.GetById(id);

            var editedPermissionTypeDto = _mapper.Map<PermissionType, PermissionTypeDto>(editedPermissionType);

            return Ok(editedPermissionTypeDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permissionType = await _service.GetById(id);

            if (permissionType == null)
            {
                return NotFound();
            }

            await _service.Remove(permissionType);

            return NoContent();
        }
    }
}
