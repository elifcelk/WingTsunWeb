using Application.Admin.Features.GalleryFeatures.Commands;
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

namespace Application.Admin.Features.VideoFeatures.Commands
{
    public class AddVideoCommand : IRequest<Response<bool>>
    {
        public string VideoUrl { get; set; }
        public AddVideoCommand(string videoUrl)
        {
            VideoUrl = videoUrl;
        }

        public class AddVideoCommandHandler : IRequestHandler<AddVideoCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddVideoCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddVideoCommand request, CancellationToken cancellationToken)
            {
                Video video = new Video
                {
                    Id = Guid.NewGuid(),
                    Path = request.VideoUrl,
                    CreatedTime = DateTime.Now
                };

                _context.Videos.Add(video);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
