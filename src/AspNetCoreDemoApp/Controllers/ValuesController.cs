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

            List<string> envVars = new List<string>();

            Console.WriteLine("Current Directory: " + System.IO.Directory.GetCurrentDirectory());

            var directory = new System.IO.DirectoryInfo("/app/contrast/runtimes/linux-x64/native/");
            if (directory == null)
            {
                Console.Write("profiler directory: NULL");
                envVars.Add("profiler directory: NULL");
            }
            else
            {
                Console.WriteLine("profiler directory count: " + directory.GetFiles().Length);
                envVars.Add("profiler directory count: " + directory.GetFiles().Length);

                foreach(var x in directory.GetFiles())
                {
                    Console.WriteLine(" - profiler directory: " + x.FullName);
                    envVars.Add(" - profiler directory: " + x.FullName);
                }
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