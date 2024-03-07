using AutoMapper;
using TimelineService.DTO;
using TimelineService.Repository;
using TweetService.Models;

namespace TimelineService.Service;

public class TimelineDataService: ITimelineDataService
{
    private readonly ITimelineRepository _repo;
    private IMapper _mapper;
    
    public TimelineDataService(ITimelineRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<TimelineResponseDto> GetTimelineByUserId(int id)
    {
        var timeline = await _repo.GetTimelineByUserId(id);
        var mapped = _mapper.Map<TimelineResponseDto>(timeline);
        return mapped;
    }
}