using Application.Admin.Models;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Admin.Features.AdminFeatures.Commands
{
    public class DeleteAdminCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteAdminCommand(ChangeModel model)
        {
            this.model = model;
        }
        public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, Response<bool>>
        {
            IApplicationDbContext _context;

            public DeleteAdminCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Response<bool>> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
            {
                AdminUser? admin = _context.AdminUsers.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (admin == null)
                {
                    return new Response<bool>("Yönetici bulunamadı.");
                }

                _context.AdminUsers.Remove(admin);

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
