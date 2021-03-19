using AutoMapper;
using GameDatabase.Interfaces;
using GamesDatabaseBusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
            try
            {
                var genres = await _commonService.GetAllGenres();
                List<SelectListItem> ddlItems = _mapper.Map<IEnumerable<Genre>, List<SelectListItem>>(genres);
                return Ok(ddlItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Games/5
        [HttpPost]
        public async Task<IActionResult> FavouriteGame(int gameId, int userId)
        {
            try
            {
                await _commonService.FavouriteGame(gameId, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
