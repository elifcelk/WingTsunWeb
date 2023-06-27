using Application.Admin.Features.SliderFeatures.Commands;
using Application.Admin.Models;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.GalleryFeatures.Commands
{
    public class ChangePhotoStatusCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public ChangePhotoStatusCommand(ChangeModel model)
        {
            this.model = model;
        }

        public class ChangePhotoStatusCommandHandler : IRequestHandler<ChangePhotoStatusCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public ChangePhotoStatusCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(ChangePhotoStatusCommand request, CancellationToken cancellationToken)
            {
                var photo = _context.Galleries.IgnoreQueryFilters().Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (photo == null)
                {
                    return new Response<bool>("Resim bulunamadı.");
                }
                if (photo.IsDeleted)
                    photo.IsDeleted = false;
                else
                    photo.IsDeleted = true;

                photo.UpdatedTime = DateTime.Now;

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
