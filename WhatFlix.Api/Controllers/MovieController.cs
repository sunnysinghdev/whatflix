using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//using Newtonsoft.Json;
using WhatFlix.Api.Model;
using WhatFlix.Common;

namespace WhatFlix.Api.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        private IUnitOfWork unitOfWork;
        public MovieController(ILogger<ErrorController> logger, IUnitOfWork ut)
        {
            _logger = logger;
            unitOfWork = ut;
        }
        [HttpGet("users")]
        public JsonResult Get()
        {
            //Console.WriteLine("oooo");

            string s="Fail";//
            using(StreamReader sr = new StreamReader("wwwroot/user_preferences.json")){
                s = sr.ReadToEnd();
                
            }
            _logger.Log(LogLevel.Information, "H1");
            return new JsonResult(s);
        }
        [HttpGet("user/{id:int}/search")]
        public IEnumerable<Object> Search(int id, string text)
        {
            string val = text;
            Console.WriteLine(val);
            var l = new WhatFlix.Services.MovieService(unitOfWork);
            return l.GetAllMovie(text);
            
            //return string.Format("user id = {0}, search string={1}",id, val);
        }
        
    }
}