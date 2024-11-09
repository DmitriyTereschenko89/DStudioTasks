using System.ComponentModel.DataAnnotations;
using DStudioTasks.Domain.Common;

namespace DStudioTasks.Domain.Entities
{
    public class Task
    {
        [Key]
        public int Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
    }
}
