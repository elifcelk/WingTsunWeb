using Application.Admin.Features.SliderFeatures.Commands;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Admin.Features.GalleryFeatures.Commands
{
    public class AddGalleryCommand : IRequest<Response<bool>>
    {
        public string ImageUrl { get; set; }
        public AddGalleryCommand(string imageUrl)
        {
            ImageUrl = imageUrl;
        }

        public class AddGalleryCommandHandler : IRequestHandler<AddGalleryCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddGalleryCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddGalleryCommand request, CancellationToken cancellationToken)
            {
                Gallery gallery = new Gallery
                {
                    Id = Guid.NewGuid(),
                    PhotoPath = request.ImageUrl,
                    CreatedTime = DateTime.Now
                };

                _context.Galleries.Add(gallery);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
