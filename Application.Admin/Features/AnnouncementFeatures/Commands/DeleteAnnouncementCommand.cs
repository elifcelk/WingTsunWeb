using Application.Admin.Features.SchoolFeatures.Commands;
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

namespace Application.Admin.Features.AnnouncementFeatures.Commands
{
    public class DeleteAnnouncementCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteAnnouncementCommand(ChangeModel model)
        {
            this.model = model;
        }

        public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public DeleteAnnouncementCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
            {
                Announcement? announcement = _context.Announcements.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (announcement == null)
                {
                    return new Response<bool>("Duyuru bulunamadı.");
                }

                _context.Announcements.Remove(announcement);

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
