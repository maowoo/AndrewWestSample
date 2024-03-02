using Microsoft.AspNetCore.Mvc;
using WebAssemblySample.Shared;

namespace WebAssemblySample.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private static string[] _words ={
            "cow","goat","chicken","pig"
        };

        public DemoController()
        {
            
        }

        [HttpGet]
        public EditDto Get()
        {
            return new EditDto
            {
                ParentNumber1 = GetRandomNumber(),
                ParentNumber2 = GetRandomNumber(),
                ChildNumber1 = GetRandomNumber(),
                ParentString1 = GetRandomString(),
                ChildString1 = GetRandomString(),
                ChildTitle = GetRandomString(),
                ParentTitle = GetRandomString()
            };

        }

        [HttpGet, Route("GetChildData")]
        public ChildEditDto GetChildData()
        {
            return new ChildEditDto
            {
                ChildNumber1 = GetRandomNumber(),
                ChildString1 = GetRandomString(),
                ChildTitle = GetRandomString()
            };
        }

        private int GetRandomNumber()
        {
            return Random.Shared.Next(1, 100);
        }

        private string GetRandomString()
        {
            return _words[Random.Shared.Next(0, 4)];
        }
    }
}
