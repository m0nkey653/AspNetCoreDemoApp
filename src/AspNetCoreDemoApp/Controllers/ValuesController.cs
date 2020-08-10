using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoApp.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : ControllerBase
	{
		// GET: api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
		    Console.WriteLine(Request.GetDisplayUrl());
		    Console.WriteLine(Request.GetEncodedUrl());

            var env = Environment.GetEnvironmentVariables();

            Console.WriteLine("ENVIRONMENT COUNT: " + env.Count);
            List<string> envVars = new List<string>();
            foreach (var i in env.Keys)
            {
                Console.WriteLine("ENVIRONMENT: " + i.ToString() + ": " + env[i]);
                envVars.Add("ENVIRONMENT: " + i.ToString() + ": " + env[i]);
                //HttpContext.Response.WriteAsync("ENVIRONMENT: " + i.ToString() + ": " + env[i]);
            }
            return envVars;

			//return new[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}
	}
}