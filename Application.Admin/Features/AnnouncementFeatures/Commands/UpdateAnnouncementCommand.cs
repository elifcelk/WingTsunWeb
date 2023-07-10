using Application.Admin.DTOs.Announcement;
using Application.Admin.DTOs.School;
using Application.Admin.Features.SchoolFeatures.Commands;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.AnnouncementFeatures.Commands
{
    public class UpdateAnnouncementCommand : IRequest<Response<bool>>
    {
        public AnnouncementDTO model { get; set; }

        public UpdateAnnouncementCommand(AnnouncementDTO model)
        {
            this.model = model;
        }


        public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public UpdateAnnouncementCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
            {
                var announcement = _context.Announcements.Where(k => k.Id == request.model.Id).FirstOrDefault();

                if (request.model.MainImage != null)
                {
                    announcement!.MainImage = request.model.MainImage;
                }

                announcement.Title = request.model.Name;
                announcement.Content = request.model.Content;
                announcement.AnnouncementType = (Domain.Enums.Enums.AnnouncementType)request.model.Type;
                announcement.UpdatedTime = DateTime.Now;


                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
