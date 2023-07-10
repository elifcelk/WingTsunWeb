using Application.Admin.DTOs.Announcement;
using Application.Admin.DTOs.School;
using Application.Admin.Features.SchoolFeatures.Commands;
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

namespace Application.Admin.Features.AnnouncementFeatures.Commands
{
    public class AddAnnouncementCommand : IRequest<Response<bool>>
    {
        public AnnouncementDTO model { get; set; }

        public AddAnnouncementCommand(AnnouncementDTO model)
        {
            this.model = model;
        }
        public class AddAnnouncementCommandHandler : IRequestHandler<AddAnnouncementCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddAnnouncementCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddAnnouncementCommand request, CancellationToken cancellationToken)
            {
                Announcement announcement = new Announcement
                {
                    Id = Guid.NewGuid(),
                    Title = request.model.Name,
                    Content = request.model.Content,
                    AnnouncementType = (Domain.Enums.Enums.AnnouncementType)request.model.Type,
                    MainImage = request.model.MainImage,
                    CreatedTime = DateTime.Now
                };

                _context.Announcements.Add(announcement);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
