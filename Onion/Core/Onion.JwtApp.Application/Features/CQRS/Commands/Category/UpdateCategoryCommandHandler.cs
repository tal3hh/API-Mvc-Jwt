﻿using MediatR;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Domain.Entities;


namespace Onion.JwtApp.Application.Features.CQRS.Commands.Category
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Onion.JwtApp.Domain.Entities.Category> _repo;

        public UpdateCategoryCommandHandler(IRepository<Onion.JwtApp.Domain.Entities.Category> repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var unchange = await _repo.FindAsync(request.Id);

            if (unchange != null)
            {
                var entity = new Onion.JwtApp.Domain.Entities.Category
                {
                    Id = request.Id,
                    Name = request.Name,
                };

                await _repo.Update(entity, unchange);
            }
        }
    }
}
