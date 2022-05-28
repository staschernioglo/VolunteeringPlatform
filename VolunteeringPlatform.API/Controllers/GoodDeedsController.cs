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
        public async Task<PaginatedResult<GoodDeedListDto>> GetPagedGoodDeeds(PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            var pagedGoodDeedsDto = await _goodDeedService.GetPagedGoodDeedsAsync(pagedRequest, cancellationToken);
            return pagedGoodDeedsDto;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<GoodDeedDto> GetGoodDeed(int id, CancellationToken cancellationToken)
        {
            var goodDeedDto = await _goodDeedService.GetGoodDeedAsync(id, cancellationToken);
            return goodDeedDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoodDeed(GoodDeedForCreateDto goodDeedForCreateDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.GetLoggedInUserId();
            goodDeedForCreateDto.UserId = userId;

            var goodDeedDto = await _goodDeedService.CreateGoodDeedAsync(goodDeedForCreateDto, cancellationToken);

            return CreatedAtAction(nameof(GetGoodDeed), new { id = goodDeedDto.Id }, goodDeedDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoodDeed(int id, GoodDeedForUpdateDto goodDeedForUpdateDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _goodDeedService.UpdateGoodDeedAsync(id, goodDeedForUpdateDto, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteGoodDeed(int id, CancellationToken cancellationToken)
        {
            await _goodDeedService.DeleteGoodDeedAsync(id, cancellationToken);
        }

    }
}
