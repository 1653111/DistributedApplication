using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiService.Data;
using ApiService.Models;

namespace ApiService.Controllers
{
    [ApiController]
    [Route("api/qst")]
    public class QuestionManagementController: ControllerBase
    {
        private readonly ILogger<QuestionManagementController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public QuestionManagementController(ILogger<QuestionManagementController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("{Id}")]
        public Response<List<QuestionManagement>> GetQuestionsByUserId(int Id)
        {
            var questions = _dbContext.Questions.Where(e => e.user_id == Id).ToList();
            var obj = new Response<List<QuestionManagement>>()
            {
                Message = "OK",
                Success = true,
                Data = questions,
            };
            return obj;
        }

        [HttpPost]
        [Route("save")]
        public Response<string> Save(QuestionManagement question)
        {
            var res = new Response<string>()
            {
                Message = "OK",
                Success = true,
            };
            if (question.qst_id == null)
            {
                try
                {
                    _dbContext.Questions.Add(question);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    res.Message = e.Message;
                    res.Success = false;
                    return res;
                }
            }
            else
            {
                try
                {
                    var update = _dbContext.Questions.FirstOrDefault(e => e.qst_id == question.qst_id);
                    QuestionManagement.Copy(ref question, ref update);
                    _dbContext.Questions.Update(update);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    res.Message = e.Message;
                    res.Success = false;
                    return res;
                }
            }
            res.Message = "OK";
            res.Success = true;
            return res;
        }
    }
}
