using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using TestAPIToExtractXML.Repository;
using TestAPIToExtractXML.Model;

namespace TestAPIToExtractXML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult Email_GetToExtract(String email)
        {
            EmailRepository emr = new EmailRepository();
            if (emr.ValidateMessage(email))
            {
                //fetch extracted data after calculation
                ExtraxtedData data =  emr.ExtractEmailContent(email);
                if (data.CostCentre == "UNKNOWN")
                {
                    return BadRequest(data);
                }
                else
                {
                    return Ok(data);
                }
            }
            else
            {              
                return BadRequest();
            }
        }

    }
}
