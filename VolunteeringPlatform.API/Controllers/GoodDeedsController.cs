using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunteeringPlatform.API.Infrastructure.Extentions;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.GoodDeed;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.API.Controllers
{
    [Route("api/gooddeeds")]
    public class GoodDeedsController : BaseController
    {
        private readonly IGoodDeedService _goodDeedService;

        public GoodDeedsController(IGoodDeedService goodDeedService)
        {
            _goodDeedService = goodDeedService;
        }

        [AllowAnonymous]
        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<GoodDeedListDto>> GetPagedGoodDeeds(PagedRequest pagedRequest)
        {
            var pagedGoodDeedsDto = await _goodDeedService.GetPagedGoodDeeds(pagedRequest);
            return pagedGoodDeedsDto;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<GoodDeedDto> GetGoodDeed(int id)
        {
            var goodDeedDto = await _goodDeedService.GetGoodDeed(id);
            return goodDeedDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoodDeed(GoodDeedForCreateDto goodDeedForCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.GetLoggedInUserId();
            goodDeedForCreateDto.UserId = userId;

            var goodDeedDto = await _goodDeedService.CreateGoodDeed(goodDeedForCreateDto);

            return CreatedAtAction(nameof(GetGoodDeed), new { id = goodDeedDto.Id }, goodDeedDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoodDeed(int id, GoodDeedForUpdateDto goodDeedForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _goodDeedService.UpdateGoodDeed(id, goodDeedForUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteGoodDeed(int id)
        {
            await _goodDeedService.DeleteGoodDeed(id);
        }

    }
}
