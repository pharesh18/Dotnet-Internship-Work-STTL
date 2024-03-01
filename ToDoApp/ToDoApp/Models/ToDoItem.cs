using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class ToDoItem
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Task Length Must be less than 100 characters")]
        public string Task { get; set; }
        [Required, DefaultValue(false)]
        public bool IsCompleted { get; set; }
    } 
}