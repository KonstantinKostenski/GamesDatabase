using AutoMapper;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameDatabase.APIControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        ICommonService _commonService;
        IMapper _mapper;

        public CommonController(ICommonService commonService, IMapper mapper)
        {
            _commonService = commonService;
            _mapper = mapper;
        }

        // DELETE: api/Games/5
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _commonService.GetAllGenres();
            List<SelectListItem> ddlItems = _mapper.Map<IEnumerable<Genre>, List<SelectListItem>>(genres);
            return Ok(ddlItems);
        }
    }
}
