using FluentValidation;
using Microsoft.AspNetCore.Http;
using MyApp.Application.Features.Role.CreateRole;
using MyApp.Application.Features.User.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Product.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommands>
    {
        private readonly string[] _allowedExtension = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxFileSizeInBytes = 5 * 1024 * 1024; // 5 MB
        public CreateProductValidator()
        {
            RuleFor(x => x.Barcode).NotEmpty();
            RuleFor(x => x.SKU).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.CategoryId).GreaterThan(0);
            RuleFor(x => x.UnitId).GreaterThan(0);
            RuleFor(x => x.CostPrice).GreaterThan(0);
            RuleFor(x => x.SellingPrice).GreaterThan(0);
            RuleFor(x => x.ReorderLevel).GreaterThan(0);
            RuleFor(x => x.IsTrackInventory).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.Image).Must(BeAValidImage).WithMessage($"Image must be one of the following types: {string.Join(", ", _allowedExtension)}")
                .When(x => x.Image != null)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Image)
                        .Must(HaveValidSize).WithMessage($"Image size must not exceed {MaxFileSizeInBytes / (1024 * 1024)} MB.");
                });
        }

        private bool BeAValidImage(IFormFile file)
        {
            if (file == null) return true;
            var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
            return _allowedExtension.Contains(extension);
        }

        private bool HaveValidSize(IFormFile file)
        {
            return file != null && file.Length > 0 && file.Length <= MaxFileSizeInBytes;
        }
    }
}
