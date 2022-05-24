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
        Task<PaginatedResult<GoodDeedListDto>> GetPagedGoodDeedsAsync(PagedRequest pagedRequest);

        Task<GoodDeedDto> GetGoodDeedAsync(int id);

        Task<GoodDeedDto> CreateGoodDeedAsync(GoodDeedForCreateDto goodDeedForCreateDto);

        Task UpdateGoodDeedAsync(int id, GoodDeedForUpdateDto goodDeedForUpdateDto);

        Task DeleteGoodDeedAsync(int id);
    }
}
