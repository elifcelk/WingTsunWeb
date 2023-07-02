using Application.Admin.Features.SliderFeatures.Commands;
using Application.Admin.Models;
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
    public class DeleteSchoolCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteSchoolCommand(ChangeModel model)
        {
            this.model = model;
        }

        public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public DeleteSchoolCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
            {
                School? school = _context.Schools.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (school == null)
                {
                    return new Response<bool>("Okul bulunamadı.");
                }

                school.IsDeleted = true;

                school.UpdatedTime = DateTime.Now;

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
