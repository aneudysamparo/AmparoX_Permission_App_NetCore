using System;

namespace AmparoX.PermissionApp.Api.Dtos
{
    public class PermissionDto: BaseDto<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PermissionTypeDto PermissionType { get; set; }
        public DateTime Date { get; set; }
    }
}
