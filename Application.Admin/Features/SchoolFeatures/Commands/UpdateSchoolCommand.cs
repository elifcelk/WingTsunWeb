using Application.Admin.DTOs.School;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.SchoolFeatures.Commands
{
    public class UpdateSchoolCommand : IRequest<Response<bool>>
    {
        public SchoolDTO model { get; set; }

        public UpdateSchoolCommand(SchoolDTO model)
        {
            this.model = model;
        }
        public class UpdateSchoolCommandHandler : IRequestHandler<UpdateSchoolCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public UpdateSchoolCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
            {
                var school =  _context.Schools.Where(k => k.Id == request.model.Id).FirstOrDefault();

                if (request.model.PhotoPath != null)
                {
                    school!.PhotoPath = request.model.PhotoPath;
                }

                school!.InstructorStatus = request.model.InstructorStatus;
                school.InstructorResume = request.model.InstructorResume;
                school.MapLink = request.model.MapLink;
                school.Address = request.model.Address;
                school.InstructorName = request.model.InstructorName;
                school.CityName = request.model.CityName;
                school.DistrictName = request.model.DistrictName;
                school.ContactNumber = request.model.Phone;
                school.Name = request.model.Name;
                school.TimeTable = request.model.Timetable;
                school.UpdatedTime = DateTime.Now;
                 

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
