using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkTimeNoteServer.Common.ApiConsts;
using WorkTimeNoteServer.Common.ApiConsts.ActionNames;
using WorkTimeNoteServer.Common.WebApi;
using WorkTimeNoteServer.Common.WebApi.ResponseFactory.Contracts;
using WorkTimeNoteServer.Entities;

namespace WorkTimeNoteServer.Controllers
{
    [ApiController]
    [Route(ApiSegments.TIME_NOTE)]
    public class TimeNoteController : WebApiControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public TimeNoteController(
            IResponseFactory responseFactory)
            : base(responseFactory)
        {
        }

        [HttpGet]
        [Route(TimeNoteActionNames.GET_ALL)]
        public IActionResult Get()
        {
            Random rng = new Random();

            WeatherForecast[] response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(SuccessResponseBody(response));
        }
    }
}
