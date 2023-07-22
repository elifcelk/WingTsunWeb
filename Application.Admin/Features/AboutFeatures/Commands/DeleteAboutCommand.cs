using Application.Admin.Features.ContactFeatures.Commands;
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

namespace Application.Admin.Features.AboutFeatures.Commands
{
    public class DeleteAboutCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteAboutCommand(ChangeModel model)
        {
            this.model = model;
        }

        public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public DeleteAboutCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
            {
                About? about = _context.Abouts.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (about == null)
                {
                    return new Response<bool>("Hakkımızda alanı bulunamadı.");
                }

                _context.Abouts.Remove(about);

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
