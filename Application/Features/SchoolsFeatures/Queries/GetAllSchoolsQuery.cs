using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SchoolsFeatures.Queries
{
    public class GetAllSchoolsQuery : IRequest<List<SchoolModel>>
    {
        public class GetAllSchoolsQueryHandler : IRequestHandler<GetAllSchoolsQuery, List<SchoolModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllSchoolsQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<SchoolModel>> Handle(GetAllSchoolsQuery request, CancellationToken cancellationToken)
            {
                List<SchoolModel> schools = await applicationDbContext.Schools.OrderBy(k => k.CreatedTime).Select(k => new SchoolModel()
                {
                    Id = k.Id,
                    Name = k.Name,
                    CityName = k.CityName,
                    DistrictName = k.DistrictName,
                    Address = k.Address,
                    ContactNumber = k.ContactNumber
                }).ToListAsync();

                return schools;
            }
        }
    }
}
