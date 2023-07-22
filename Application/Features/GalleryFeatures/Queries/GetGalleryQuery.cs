using Application.Features.SchoolsFeatures.Queries;
using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GalleryFeatures.Queries
{
    public class GetGalleryQuery : IRequest<List<GalleryModel>>
    {
        public class GetGalleryQueryHandler : IRequestHandler<GetGalleryQuery, List<GalleryModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetGalleryQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<GalleryModel>> Handle(GetGalleryQuery request, CancellationToken cancellationToken)
            {
                List<GalleryModel> galleries = await applicationDbContext.Galleries.Where(k => k.IsActive).OrderBy(k => k.CreatedTime).Select(k => new GalleryModel()
                {
                    Id = k.Id,
                    PhotoPath = k.PhotoPath
                }).ToListAsync();

                return galleries;
            }
        }
    }
}
