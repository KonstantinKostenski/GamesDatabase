using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameDatabase.APIControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileUpload : ControllerBase
    {
        public FileUpload()
        {

        }

        [HttpPost]
        public async Task<IActionResult> ImageUpload()
        {
            
            return await Task.FromResult(new BadRequestResult());
        }
        
    }
}
