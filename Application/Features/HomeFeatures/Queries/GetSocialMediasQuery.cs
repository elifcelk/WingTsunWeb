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
    public class GetSocialMediasQuery : IRequest<List<SocialMediaIndexModel>>
    {
        public class GetSocialMediasQueryHandler : IRequestHandler<GetSocialMediasQuery, List<SocialMediaIndexModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetSocialMediasQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<SocialMediaIndexModel>> Handle(GetSocialMediasQuery request, CancellationToken cancellationToken)
            {
                List<SocialMediaIndexModel> socialMedias = await applicationDbContext.SocialMedias.OrderBy(k => k.CreatedTime).Select(k => new SocialMediaIndexModel()
                {
                    Id = k.Id,
                    Title = k.Title,
                    Path = k.Path,
                    CreatedTime = k.CreatedTime,
                }).ToListAsync();

                return socialMedias;
            }
        }
    }
}
