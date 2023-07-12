using Application.Admin.DTOs.About;
using Application.Admin.DTOs.Announcement;
using Application.Admin.Features.AnnouncementFeatures.Commands;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.AboutFeatures.Commands
{
    public class UpdateAboutCommand : IRequest<Response<bool>>
    {
        public AboutDTO model { get; set; }

        public UpdateAboutCommand(AboutDTO model)
        {
            this.model = model;
        }

        public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public UpdateAboutCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
            {
                var about = _context.Abouts.Where(k => k.Id == request.model.Id).FirstOrDefault();

                about.Title = request.model.Title;
                about.Text = request.model.Text;
                about.UpdatedTime = DateTime.Now;


                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
