using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.GoodDeed;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Dal.Interfaces;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Bll.Services
{
    public class GoodDeedService : IGoodDeedService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GoodDeedService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GoodDeedDto> CreateGoodDeed(GoodDeedForCreateDto goodDeedForCreateDto)
        {
            var goodDeed = _mapper.Map<GoodDeed>(goodDeedForCreateDto);
            _repository.Add(goodDeed);
            await _repository.SaveChangesAsync();

            var goodDeedDto = _mapper.Map<GoodDeedDto>(goodDeed);

            return goodDeedDto;
        }

        public async Task DeleteGoodDeed(int id)
        {
            await _repository.Delete<GoodDeed>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<GoodDeedDto> GetGoodDeed(int id)
        {
            var goodDeed = await _repository.GetByIdWithInclude<GoodDeed>(id, gd => gd.User);
            var goodDeedDto = _mapper.Map<GoodDeedDto>(goodDeed);
            return goodDeedDto;
        }

        public async Task<PaginatedResult<GoodDeedListDto>> GetPagedGoodDeeds(PagedRequest pagedRequest)
        {
            var pagedGoodDeedsDto = await _repository.GetPagedData<GoodDeed, GoodDeedListDto>(pagedRequest);
            return pagedGoodDeedsDto;
        }

        public async Task UpdateGoodDeed(int id, GoodDeedForUpdateDto goodDeedForUpdateDto)
        {
            var goodDeed = await _repository.GetById<GoodDeed>(id);
            _mapper.Map(goodDeedForUpdateDto, goodDeed);
            await _repository.SaveChangesAsync();
        }
    }
}
