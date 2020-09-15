using System;

namespace AmparoX.PermissionApp.Domain.Entities
{
    public class Permission : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }
        public DateTime Date { get; set; }
    }
}
