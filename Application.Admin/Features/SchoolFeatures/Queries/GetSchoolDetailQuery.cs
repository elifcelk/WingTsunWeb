using Application.Admin.DTOs.School;
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
    public class GetSchoolDetailQuery :IRequest<SchoolDTO>
    {
        public Guid Id { get; set; }
        public GetSchoolDetailQuery(Guid ıd)
        {
            Id = ıd;
        }
        public class GetSchoolDetailQueryHandler : IRequestHandler<GetSchoolDetailQuery,SchoolDTO>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetSchoolDetailQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<SchoolDTO> Handle(GetSchoolDetailQuery request, CancellationToken cancellationToken)
            {
                SchoolDTO? schoolDetail = await applicationDbContext.Schools!.Where(k => k.Id == request.Id).Select(k => new SchoolDTO()
                {
                    Id = k.Id,
                    PhotoPath = k.PhotoPath,
                    CityName = k.CityName,
                    DistrictName = k.DistrictName,
                    InstructorName = k.InstructorName,
                    Name = k.Name,
                    Address = k.Address,
                    InstructorResume = k.InstructorResume,
                    InstructorStatus = k.InstructorStatus,
                    MapLink = k.MapLink,
                    Phone = k.ContactNumber,
                    Timetable = k.TimeTable
                }).FirstOrDefaultAsync();

                return schoolDetail;
            }
        }
    }
}
