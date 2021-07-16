using CustomDateTimeModelBinding.Core.Model;
using CustomDateTimeModelBinding.Core.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomDateTimeModelBinding.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [Route("echo-date/{date}")]
        [HttpGet]
        public DateTime? EchoDate([DateTimeModelBinder] DateTime? date)
        {
            return date;
        }

        [Route("echo-custom-date/{date}")]
        [HttpGet]
        public DateTime? EchoCustomDateFormat([DateTimeModelBinder(DateFormat = "yyyyMMdd")] DateTime? date)
        {
            return date;
        }

        [Route("echo-model")]
        [HttpPost]
        public PostData EchoModel(PostData model)
        {
            return model;
        }
    }
}