using MediatR;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Category.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryHandler(ICategoryRepository categoryRepo)
        {
            _categoryRepository = categoryRepo;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = new Categories
                {
                    CategoryName = request.CategoryName,
                    Description = request.CategoryDescription,
                    CreateAt = DateTime.Now,
                    IsActive = true
                };

                await _categoryRepository.CreateCategoryAsync(category);

                return new CreateCategoryResponse
                {
                    isSuccess = true,
                    message = "Category created successfully."
                };
            }
            catch (Exception ex)
            {
                return new CreateCategoryResponse 
                { 
                    isSuccess = false, 
                    message = ex.Message
                };
            }
        }
    }
}
