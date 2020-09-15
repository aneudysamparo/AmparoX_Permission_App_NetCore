using AmparoX.PermissionApp.Api.Dtos;
using AmparoX.PermissionApp.Domain.Entities;
using AutoMapper;

namespace AmparoX.PermissionApp.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entities to DTO
            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionType, PermissionTypeDto>();

            // DTO to Entities
            CreateMap<PermissionDto, Permission>();
            CreateMap<PermissionTypeDto, PermissionType>();

            CreateMap<SavePermissionDto, Permission>();
            CreateMap<SavePermissionTypeDto, PermissionType>();
        }
    }
}
