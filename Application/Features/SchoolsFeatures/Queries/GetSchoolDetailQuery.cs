using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SchoolsFeatures.Queries;

public class GetSchoolDetailQuery:IRequest<SchoolDetailModel>
{
    public Guid Id { get; set; }
    public GetSchoolDetailQuery(Guid Id)
    {
        this.Id = Id;
    }
    public class GetSchoolDetailQueryHandler : IRequestHandler<GetSchoolDetailQuery, SchoolDetailModel>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public GetSchoolDetailQueryHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<SchoolDetailModel> Handle(GetSchoolDetailQuery request, CancellationToken cancellationToken)
        {
            SchoolDetailModel school = await applicationDbContext.Schools.Where(k => k.Id == request.Id && !k.IsDeleted).Select(k => new SchoolDetailModel()
            {
                Id = k.Id,
                Name = k.Name,
                CityName = k.CityName,
                DistrictName = k.DistrictName,
                Address = k.Address,
                ContactNumber = k.ContactNumber,
                InstructorName = k.InstructorName,
                InstructorStatus= k.InstructorStatus,
                InstructorResume = k.InstructorResume,
                TimeTable = k.TimeTable
            }).FirstOrDefaultAsync(cancellationToken:cancellationToken);

            return school;
        }
    }
}
