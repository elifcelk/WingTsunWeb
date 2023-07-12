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
    public class GetAllAboutQuery : IRequest<List<AboutIndexModel>>
    {
        public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQuery, List<AboutIndexModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllAboutQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<AboutIndexModel>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
            {
                List<AboutIndexModel> abouts = await applicationDbContext.Abouts.OrderBy(k => k.CreatedTime).Select(k => new AboutIndexModel()
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
