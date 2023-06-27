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

namespace Application.Admin.Features.SliderFeatures.Commands
{
    public class ChangeSliderStatusCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public ChangeSliderStatusCommand(ChangeModel model)
        {
            this.model = model;
        }

        public class ChangeSliderStatusCommandHandler : IRequestHandler<ChangeSliderStatusCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public ChangeSliderStatusCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(ChangeSliderStatusCommand request, CancellationToken cancellationToken)
            {
                Slider? slider =  _context.Sliders.IgnoreQueryFilters().Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (slider == null)
                {
                    return new Response<bool>("Slider bulunamadı.");
                }
                if (slider.IsDeleted)
                    slider.IsDeleted = false;
                else
                    slider.IsDeleted = true;

                slider.UpdatedTime = DateTime.Now;

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
