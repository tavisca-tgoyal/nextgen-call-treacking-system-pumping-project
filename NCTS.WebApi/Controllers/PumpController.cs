using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NCTS.WebApi.Controllers
{
    
    [ApiController]
    public class PumpController : ControllerBase
    {
        [Route("api/pump/employee")]
        public void PumpEmployees()
        {

        }

        [Route("api/pump/Application")]
        public void PumpApplication()
        {

        }

        [Route("api/pump/CallData")]
        public void PumpCallData()
        {

        }

        [Route("api/pump/CallTree")]
        public void PumpCallTree()
        {

        }

        [Route("api/pump/EmployeeHours")]
        public void PumpEmployeeHours()
        {

        }
    }
}