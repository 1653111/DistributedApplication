using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Models
{
    public class RatingManagement
    {
        public int? qst_id { get; set; }
        public int? ans_id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string rating_type { get; set; }

        public int? good { get; set; }
        public int? normal { get; set; }
        public int? bad { get; set; }

        [Column(TypeName = "char(1)")]
        public bool isActive { get; set; }
        
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }

        public static void Copy(ref AnswerManagement model, ref AnswerManagement copy)
        {
            model.qst_id = copy.qst_id;
            model.ans_id = copy.ans_id;
            model.rating_type = copy.rating_type;
            model.good = copy.good;
            model.normal = copy.normal;
            model.bad = copy.bad;
            model.isActive = copy.isActive;
            model.createDate = copy.createDate;
            model.updateDate = copy.updateDate;
        }
    }
}
