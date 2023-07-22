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

namespace Application.Admin.Features.SliderFeatures.Commands
{
    public class DeleteSliderCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteSliderCommand(ChangeModel model)
        {
            this.model = model;
        }

        public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public DeleteSliderCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
            {
                Slider? slider = _context.Sliders.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (slider == null)
                {
                    return new Response<bool>("Slider bulunamadı.");
                }

                _context.Sliders.Remove(slider);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
