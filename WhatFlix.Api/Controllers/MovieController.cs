using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WhatFlix.Service;

namespace WhatFlix.Api.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        public static int counter = 0;//it gets initialized every time.
        private readonly ILogger<MovieController> _logger;
        //private IUnitOfWork unitOfWork;
        private IMovieService movieService;
        //UnitOfWork is instanciated using Dependency Injection;
        public MovieController(IMovieService movieService, ILogger<MovieController> logger)
        {
            _logger = logger;
            this.movieService = movieService;
        }
        [HttpGet("users")]
        public JsonResult Get()
        {
            //Console.WriteLine("oooo");

            string s = "Fail";//
            using (StreamReader sr = new StreamReader("wwwroot/user_preferences.json"))
            {
                s = sr.ReadToEnd();

            }
            _logger.Log(LogLevel.Information, "H1: You are using logging feature.");
            return new JsonResult(s);
        }
        [HttpGet("user/{id:int}/search")]
        public IEnumerable<Object> Search(int id, string text)
        {
            string val = text;
            counter++;
            Console.WriteLine(val);
            _logger.LogWarning("Request num{0} >"+counter , val);
            // _logger.LogError("LogError");
            // _logger.LogInformation("LogInformation");
            // _logger.LogDebug("LogDebug");
            // _logger.LogTrace("LogTrace");
            // _logger.LogCritical("LogCritical");
            //var l = new WhatFlix.Service.MovieService(this.unitOfWork);
            return movieService.GetAllMovie(text);

            //return string.Format("user id = {0}, search string={1}",id, val);
        }

    }


}