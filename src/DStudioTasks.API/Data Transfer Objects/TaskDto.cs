﻿using System.ComponentModel.DataAnnotations;
using DStudioTasks.Domain.Common;

namespace DStudioTasks.API.Data_Transfer_Objects
{
    public class TaskDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
