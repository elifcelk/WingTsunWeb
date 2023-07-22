using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HomeFeatures.Queries
{
    public class GetVideosQuery :IRequest<List<VideoModel>>
    {
        public class GetVideosQueryHandler : IRequestHandler<GetVideosQuery, List<VideoModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetVideosQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }
            public async Task<List<VideoModel>> Handle(GetVideosQuery request, CancellationToken cancellationToken)
            {
                List<VideoModel> videos = await applicationDbContext.Videos.Where(k => k.IsActive).OrderByDescending(k => k.CreatedTime).Where(k => !k.IsDeleted).Select(k => new VideoModel()
                {
                    Id = k.Id,
                    Path = k.Path,
                }).ToListAsync();

                return videos;
            }
        }
    }
}
