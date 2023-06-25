using Application.Admin.Models.Slider;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.SliderFeatures.Queries
{
    public class GetAllSliderQuery:IRequest<List<SliderViewModel>>
    {
        public class GetAllSliderQueryHandler : IRequestHandler<GetAllSliderQuery, List<SliderViewModel>>
        {
            private readonly IApplicationDbContext dbContext;
            public GetAllSliderQueryHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<SliderViewModel>> Handle(GetAllSliderQuery request, CancellationToken cancellationToken)
            {
                var sliderList = await dbContext.Sliders.AsNoTracking().IgnoreQueryFilters().Select(k => new SliderViewModel
                {
                    Id = k.Id,
                    Description = k.Description,
                    Title = k.Title,
                    ImageUrl = k.ImageURL,
                    IsDeleted = k.IsDeleted
                }).ToListAsync(cancellationToken: cancellationToken);

                return sliderList;
            }
        }
    }
}
