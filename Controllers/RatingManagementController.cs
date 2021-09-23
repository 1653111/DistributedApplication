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
    [Route("api/rating")]
    public class RatingManagementController: ControllerBase
    {
        private readonly ILogger<RatingManagementController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public RatingManagementController(ILogger<RatingManagementController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // [HttpGet]
        // [Route("{Id}")]
        // public Response<List<QuestionManagement>> GetQuestionsByUserId(int Id)
        // {
        //     var questions = _dbContext.Questions.Where(e => e.user_id == Id).ToList();
        //     var obj = new Response<List<QuestionManagement>>()
        //     {
        //         Message = "OK",
        //         Success = true,
        //         Data = questions,
        //     };
        //     return obj;
        // }

        [HttpPost]
        [Route("save")]
        public Response<string> Save(RatingManagement rating)
        {
            var res = new Response<string>()
            {
                Message = "OK",
                Success = true,
            };
            if (rating.qst_id == null && rating.ans_id == null)
            {
                try
                {
                    _dbContext.Ratings.Add(rating);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    res.Message = e.Message;
                    res.Success = false;
                    return res;
                }
            }
            else if (rating.qst_id != null && rating.ans_id == null)
            {
                try
                {
                    var update = _dbContext.Ratings.FirstOrDefault(e => e.qst_id == rating.qst_id);
                    RatingManagement.Copy(ref rating, ref update);
                    _dbContext.Ratings.Update(update);
                    _dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    res.Message = e.Message;
                    res.Success = false;
                    return res;
                }
            }
            else if (rating.qst_id == null && rating.ans_id != null)
            {
                try
                {
                    var update = _dbContext.Ratings.FirstOrDefault(e => e.ans_id == rating.ans_id);
                    RatingManagement.Copy(ref rating, ref update);
                    _dbContext.Ratings.Update(update);
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
