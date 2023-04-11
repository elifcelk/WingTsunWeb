using Application.Features.NewsFeatures.Queries;
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
    public class GetSchoolForHomeQuery : IRequest<List<SchoolForHomeModel>>
    {
        public class GetSchoolForHomeQueryHandler : IRequestHandler<GetSchoolForHomeQuery, List<SchoolForHomeModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetSchoolForHomeQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }
            public async Task<List<SchoolForHomeModel>> Handle(GetSchoolForHomeQuery request, CancellationToken cancellationToken)
            {
                List<SchoolForHomeModel> schools = await applicationDbContext.Schools.OrderBy(k => k.CreatedTime).Where(k => !k.IsDeleted).Select(k => new SchoolForHomeModel()
                {
                    Id = k.Id,
                    Name = k.Name,
                    DistrictName = k.DistrictName,
                    PhotoPath = k.PhotoPath
                }).ToListAsync();

                return schools;
            }
        }
    }
}
