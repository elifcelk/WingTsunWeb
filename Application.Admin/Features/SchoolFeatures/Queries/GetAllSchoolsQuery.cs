using Application.Admin.Features.GalleryFeatures.Queries;
using Application.Admin.Models.Gallery;
using Application.Admin.Models.School;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.SchoolFeatures.Queries
{
    public class GetAllSchoolsQuery : IRequest<List<SchoolViewModel>>
    {
        public class GetAllSchoolsQueryHandler : IRequestHandler<GetAllSchoolsQuery, List<SchoolViewModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllSchoolsQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<SchoolViewModel>> Handle(GetAllSchoolsQuery request, CancellationToken cancellationToken)
            {
                List<SchoolViewModel> allSchools = await applicationDbContext.Schools.AsNoTracking().OrderByDescending(k => k.CreatedTime).Select(k => new SchoolViewModel()
                {
                    Id = k.Id,
                    PhotoPath = k.PhotoPath,
                    CityName = k.CityName,
                    DistrictName = k.DistrictName,
                    InstructorName = k.InstructorName,
                    Name = k.Name
                }).ToListAsync();

                return allSchools;
            }
        }
    }
}
