using Application.Admin.Features.ContactFeatures.Queries;
using Application.Admin.Models.SocialMedia;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.SocialMediaFeatures.Queries
{
    public class GetAllSocialMediaForAdminQuery : IRequest<List<SocialMediaIndexModel>>
    {
        public class GetAllSocialMediaForAdminQueryHandler : IRequestHandler<GetAllSocialMediaForAdminQuery, List<SocialMediaIndexModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllSocialMediaForAdminQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<SocialMediaIndexModel>> Handle(GetAllSocialMediaForAdminQuery request, CancellationToken cancellationToken)
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
