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

namespace Application.Admin.Features.GalleryFeatures.Commands
{
    public class DeleteGalleryCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteGalleryCommand(ChangeModel model)
        {
            this.model = model;
        }

        public class DeleteGalleryCommandHandler : IRequestHandler<DeleteGalleryCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public DeleteGalleryCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
            {
                Gallery? gallery = _context.Galleries.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (gallery == null)
                {
                    return new Response<bool>("Resim bulunamadı.");
                }

                _context.Galleries.Remove(gallery);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }

    }
}
