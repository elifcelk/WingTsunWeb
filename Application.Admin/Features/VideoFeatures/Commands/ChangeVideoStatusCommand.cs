using Application.Admin.Features.GalleryFeatures.Commands;
using Application.Admin.Models;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.VideoFeatures.Commands
{
    public class ChangeVideoStatusCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public ChangeVideoStatusCommand(ChangeModel model)
        {
            this.model = model;
        }
        public class ChangeVideoStatusCommandHandler : IRequestHandler<ChangeVideoStatusCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public ChangeVideoStatusCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(ChangeVideoStatusCommand request, CancellationToken cancellationToken)
            {
                var video = _context.Videos.IgnoreQueryFilters().Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (video == null)
                {
                    return new Response<bool>("Video bulunamadı.");
                }
                if (video.IsDeleted)
                    video.IsDeleted = false;
                else
                    video.IsDeleted = true;

                video.UpdatedTime = DateTime.Now;

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
