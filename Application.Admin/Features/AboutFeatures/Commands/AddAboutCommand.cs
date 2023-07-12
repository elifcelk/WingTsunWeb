using Application.Admin.DTOs.About;
using Application.Admin.DTOs.Contact;
using Application.Admin.Features.ContactFeatures.Commands;
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
    public class AddAboutCommand : IRequest<Response<bool>>
    {
        public AboutDTO model { get; set; }
        public AddAboutCommand(AboutDTO model)
        {
            this.model = model;
        }

        public class AddAboutCommandHandler : IRequestHandler<AddAboutCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddAboutCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddAboutCommand request, CancellationToken cancellationToken)
            {
                About about = new About
                {
                    Id = Guid.NewGuid(),
                    Title = request.model.Title,
                    Text = request.model.Text,
                    CreatedTime = DateTime.Now
                };

                _context.Abouts.Add(about);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
