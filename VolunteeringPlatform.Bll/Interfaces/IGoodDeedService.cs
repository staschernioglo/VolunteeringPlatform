using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Dtos.GoodDeed;
using VolunteeringPlatform.Common.Models.PagedRequest;

namespace VolunteeringPlatform.Bll.Interfaces
{
    public interface IGoodDeedService
    {
        Task<PaginatedResult<GoodDeedListDto>> GetPagedGoodDeeds(PagedRequest pagedRequest);

        Task<GoodDeedDto> GetGoodDeed(int id);

        Task<GoodDeedDto> CreateGoodDeed(GoodDeedForCreateDto goodDeedForCreateDto);

        Task UpdateGoodDeed(int id, GoodDeedForUpdateDto goodDeedForUpdateDto);

        Task DeleteGoodDeed(int id);
    }
}
