using ECommerce.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ValidationRules.FluentValidation
{
    public class CreateProductValidator : AbstractValidator<VMCreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().NotNull().WithMessage("Lütfen ürün adı giriniz")
                .MinimumLength(4).MaximumLength(200).WithMessage("Lütfen ürün ismini 4 ile 200 karakter arası giriniz");


            RuleFor(product => product.Description)
                .NotEmpty().NotNull().WithMessage("Lütfen ürün açıklaması giriniz!")
                .MinimumLength(1).MaximumLength(2000).WithMessage("Lütfen ürün açıklamasını 1 ile 2000 karakter arası giriniz");


            RuleFor(product => product.UnitPrice)
                .NotEmpty().NotNull().WithMessage("Lütfen ürünün fiyatını giriniz")
                .Must(p => p > 0).WithMessage("Lütfen ürünün fiyatını 0 dan yüksek giriniz.");
        }
    }
}
