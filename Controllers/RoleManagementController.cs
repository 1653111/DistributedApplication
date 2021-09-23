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
    [Route("api/role")]
    public class RoleManagementController: ControllerBase
    {
        private readonly ILogger<RoleManagementController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public RoleManagementController(ILogger<RoleManagementController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("save")]
        public Response<string> Save(RoleManagement role)
        {
            var res = new Response<string>()
            {
                Message = "OK",
                Success = true,
            };
            if (role.role_id == null)
            {
                try
                {
                    _dbContext.Questions.Add(role);
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
                    var update = _dbContext.Roles.FirstOrDefault(e => e.role_id == role.role_id);
                    RoleManagement.Copy(ref role, ref update);
                    _dbContext.Roles.Update(update);
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
