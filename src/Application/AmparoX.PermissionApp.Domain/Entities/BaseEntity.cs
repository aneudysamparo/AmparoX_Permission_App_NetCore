using System.ComponentModel.DataAnnotations.Schema;

namespace AmparoX.PermissionApp.Domain.Entities
{
    public class BaseEntity<TId>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TId Id { get; set; }
    }
}
