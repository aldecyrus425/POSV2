using MediatR;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Product.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommands, CreateProductResponse>
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepo;

        public CreateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepo, IUnitOfWork unitOfWork, IUnitRepository unitRepo)
        {
            _productRepo = productRepository;
            _categoryRepo = categoryRepo;
            _unitOfWork = unitOfWork;
            _unitRepo = unitRepo;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommands request, CancellationToken cancellationToken)
        {
            if (request.Products == null || !request.Products.Any())
            {
                return new CreateProductResponse
                {
                    isSuccess = false,
                    message = "No products provided."
                };
            }

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var categoryIds = request.Products.Select(p => p.CategoryId).Distinct().ToList();
                var unitIds = request.Products.Select(p => p.UnitId).Distinct().ToList();

                var categories = await _categoryRepo.GetCategoriesByIdsAsync(categoryIds);
                var units = await _unitRepo.getUnitsByIdAsync(unitIds);

                var categoryLookup = categories.ToDictionary(c => c.CategoryId);
                var unitLookup = units.ToDictionary(u => u.UnitId);

                var errors = new List<string>();
                var productsToCreate = new List<Products>();

                foreach (var (item, index) in request.Products.Select((p, i) => (p, i)))
                {
                    if (!categoryLookup.TryGetValue(item.CategoryId, out var category))
                    {
                        errors.Add($"Item {index}: Category '{item.CategoryId}' not found.");
                        continue;
                    }

                    if (!unitLookup.TryGetValue(item.UnitId, out var unit))
                    {
                        errors.Add($"Item {index}: Unit '{item.UnitId}' not found.");
                        continue;
                    }

                    productsToCreate.Add(new Products
                    {
                        Barcode = item.Barcode,
                        SKU = item.SKU,
                        Name = item.Name,
                        Description = item.Description,
                        CategoryId = item.CategoryId,
                        UnitId = item.UnitId,
                        CostPrice = item.CostPrice,
                        SellingPrice = item.SellingPrice,
                        ReorderLevel = item.ReorderLevel,
                        IsTrackInventory = item.IsTrackInventory,
                        IsActive = item.IsActive,
                        ImageUrl = item.Image
                    });
                }

                if (errors.Any())
                {
                    await _unitOfWork.RollBackTransactionAsync();
                    return new CreateProductResponse
                    {
                        isSuccess = false,
                        message = string.Join("; ", errors)
                    };
                }

                await _productRepo.addProduct(productsToCreate);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync();

                return new CreateProductResponse
                {
                    isSuccess = true,
                    message = $"{productsToCreate.Count} product(s) created successfully."
                };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackTransactionAsync();
                return new CreateProductResponse
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }
    }
}
