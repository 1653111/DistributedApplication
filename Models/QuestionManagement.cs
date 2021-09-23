using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Models
{
    public class QuestionManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? qst_id { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string qst_tag { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string qst_cont { get; set; }
        public int category_id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string rating { get; set; }
        public int user_id { get; set; }
        [Column(TypeName = "char(1)")]
        public bool isPublished { get; set; }
        [Column(TypeName = "char(1)")]
        public bool isActive { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }

        public static void Copy(ref QuestionManagement model, ref QuestionManagement copy)
        {
            model.qst_id = copy.qst_id;
            model.qst_tag = copy.qst_tag;
            model.qst_cont = copy.qst_cont;
            model.category_id = copy.category_id;
            model.rating = copy.rating;
            model.user_id = copy.user_id;
            model.isActive = copy.isActive;
            model.isPublished = copy.isPublished;
            model.createDate = copy.createDate;
            model.updateDate = copy.updateDate;
        }
    }
}
