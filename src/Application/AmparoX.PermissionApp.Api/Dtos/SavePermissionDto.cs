using System;

namespace AmparoX.PermissionApp.Api.Dtos
{
    public class SavePermissionDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime Date { get; set; }
    }
}
