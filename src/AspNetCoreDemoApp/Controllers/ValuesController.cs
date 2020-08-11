using System;
using System.Collections.Generic;
using System.IO;
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

            List<string> envVars = new List<string>();

            Console.WriteLine("Current Directory: " + System.IO.Directory.GetCurrentDirectory());

            try
            {
                string[] allfiles = Directory.GetFiles("/app/heroku_output", "*.*", SearchOption.AllDirectories);

                Console.WriteLine("All Files count: " + allfiles.Length);
                envVars.Add("All Files count: " + allfiles.Length);

                foreach (var x in allfiles)
                {
                    Console.WriteLine(" - " + x);
                    envVars.Add(" - " + x);
                }
            }
            catch(Exception ex)
            {
                Console.Write("All Files Exception: " + ex.ToString());
                envVars.Add("All Files Exception: " + ex.ToString());
            }

            //Get environment
            var env = Environment.GetEnvironmentVariables();
            Console.WriteLine("ENVIRONMENT COUNT: " + env.Count);
            envVars.Add("ENVIRONMENT COUNT: " + env.Count);
            foreach (var i in env.Keys)
            {
                Console.WriteLine("ENVIRONMENT: " + i.ToString() + ": " + env[i]);
                envVars.Add("ENVIRONMENT: " + i.ToString() + ": " + env[i]);
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