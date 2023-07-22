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

namespace Application.Admin.Features.VideoFeatures.Commands
{
    public class DeleteVideoCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteVideoCommand(ChangeModel model)
        {
            this.model = model;
        }

        public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public DeleteVideoCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
            {
                Video? video = _context.Videos.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (video == null)
                {
                    return new Response<bool>("Video bulunamadı.");
                }

                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
