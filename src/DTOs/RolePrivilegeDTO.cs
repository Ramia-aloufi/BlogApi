using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.Models;

namespace BlogApi.src.DTOs
{
    public class RolePrivilegeDTO
    {

        public int Id { get; set; }
        [Required]
        public string RolePrivilegeName { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int RoleId{ get; set; }
         public  bool isActive { get; set; }
        public  bool isDeleted { get; set; }

    }
}