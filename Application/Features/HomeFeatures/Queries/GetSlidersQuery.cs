using Application.Features.SchoolsFeatures.Queries;
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
    public class GetSlidersQuery : IRequest<List<SliderModel>>
    {
        public class GetSlidersQueryHandler : IRequestHandler<GetSlidersQuery, List<SliderModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetSlidersQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<SliderModel>> Handle(GetSlidersQuery request, CancellationToken cancellationToken)
            {
                List<SliderModel> sliders = await applicationDbContext.Sliders.Where(k => k.IsActive).OrderByDescending(k => k.CreatedTime).Select(k => new SliderModel()
                {
                    Id = k.Id,
                    CreatedTime = k.CreatedTime,
                    Description = k.Description,
                    ImageURL = k.ImageURL,
                    Title = k.Title
                }).ToListAsync();

                return sliders;
            }
        }
    }
}
