using Application.Admin.Models.Video;
using Application.Features.HomeFeatures.Queries;
using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.VideoFeatures.Queries
{
    public class GetAllVideosQuery : IRequest<List<VideoViewModel>>
    {
        public class GetAllVideosQueryHandler : IRequestHandler<GetAllVideosQuery, List<VideoViewModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllVideosQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }
            public async Task<List<VideoViewModel>> Handle(GetAllVideosQuery request, CancellationToken cancellationToken)
            {
                List<VideoViewModel> videos = await applicationDbContext.Videos.AsNoTracking().OrderByDescending(k => k.CreatedTime).Select(k => new VideoViewModel()
                {
                    Id = k.Id,
                    Path = k.Path,
                    IsDeleted = k.IsDeleted,
                    IsActive = k.IsActive,
                }).ToListAsync();

                return videos;
            }
        }
    }
}
