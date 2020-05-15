using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//using Newtonsoft.Json;
//using WhatFlix.Api.Model;
//using WhatFlix.Services;
using Covid19.Domain;
using Covid19.Repository;
using Microsoft.Azure.Cosmos;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DataAccessLayer.Covid19;
using Covid19.Service;

namespace WhatFlix.Api.Controllers
{
    [ApiController]
    [Route("covid19")]
    public class Covid19Controller : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        private Covid19DbContext _context;
        //private IUnitOfWork unitOfWork;
        public Covid19Controller(ILogger<ErrorController> logger, IConfiguration configuration)
        {
            _logger = logger;
            //unitOfWork = ut;
            //var res  = ConfigurationManager.GetSection("AzureCosmosDB");
            Console.WriteLine(configuration["AzureCosmosDB"]);
            string EndpointUri = configuration["AzureCosmosDB:EndPointUrl"];
            string PrimaryKey = configuration["AzureCosmosDB:PrimaryKey"];
            _context  = new Covid19DbContext(EndpointUri, PrimaryKey);
            
        }
        [HttpGet("location")]
        public async Task<IEnumerable<Location>> Get()
        {
            var service  = new Covid19Service(this._context);
            return await service.GetAll();
        }

        [HttpPost("location")]
        public IActionResult Add([FromBody]Location location)
        {
            var service  = new Covid19Service(this._context);
            service.Add(location);

            return Ok("result creted.");

        }
        
        
    }
}