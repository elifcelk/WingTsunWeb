using Application.Admin.Features.ContactFeatures.Queries;
using Application.Admin.Models.About;
using Application.Admin.Models.Contact;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.AboutFeatures.Queries
{
    public class GetAllAboutForAdminQuery : IRequest<List<AboutIndexModel>>
    {
        public class GetAllAboutForAdminQueryHandler : IRequestHandler<GetAllAboutForAdminQuery, List<AboutIndexModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllAboutForAdminQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<AboutIndexModel>> Handle(GetAllAboutForAdminQuery request, CancellationToken cancellationToken)
            {
                List<AboutIndexModel> abouts = await applicationDbContext.Abouts.OrderByDescending(k => k.CreatedTime).Select(k => new AboutIndexModel()
                {
                    Id = k.Id,
                    Title = k.Title,
                    Text = k.Text,
                    CreatedTime = k.CreatedTime,
                }).ToListAsync();

                return abouts;
            }
        }
    }
}
