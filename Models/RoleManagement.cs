using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Models
{
    public class RoleManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? role_id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string role_name { get; set; }

        [Column(TypeName = "char(1)")]
        public bool isActive { get; set; }
        
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }

        public static void Copy(ref AnswerManagement model, ref AnswerManagement copy)
        {
            model.role_id = copy.role_id;
            model.role_name = copy.role_name;
            model.isActive = copy.isActive;
            model.createDate = copy.createDate;
            model.updateDate = copy.updateDate;
        }
    }
}
