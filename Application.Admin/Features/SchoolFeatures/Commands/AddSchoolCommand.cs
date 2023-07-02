using Application.Admin.DTOs.School;
using Application.Admin.DTOs.Slider;
using Application.Admin.Features.SliderFeatures.Commands;
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
    public class AddSchoolCommand : IRequest<Response<bool>>
    {
        public SchoolDTO model { get; set; }

        public AddSchoolCommand(SchoolDTO model)
        {
            this.model = model;
        }
        public class AddSchoolCommandHandler : IRequestHandler<AddSchoolCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddSchoolCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddSchoolCommand request, CancellationToken cancellationToken)
            {
                if (request.model.PhotoPath == null)
                    return new Response<bool>("Resim yüklemediniz.");

                School school = new School
                {
                    Id = Guid.NewGuid(),
                    PhotoPath = request.model.PhotoPath,
                    Address = request.model.Address,
                    Name = request.model.Name,
                    CityName = request.model.CityName,
                    DistrictName = request.model.DistrictName,
                    ContactNumber = request.model.Phone,
                    InstructorName = request.model.InstructorName,
                    InstructorResume = request.model.InstructorResume,
                    InstructorStatus = request.model.InstructorStatus,
                    MapLink = request.model.MapLink,
                    TimeTable = request.model.Timetable,
                    CreatedTime = DateTime.Now
                };

                _context.Schools.Add(school);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
