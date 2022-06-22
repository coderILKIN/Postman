using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.DTOs
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal SoldPrice { get; set; }
        public decimal CostPrice { get; set; }
    }
    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Do not enter blank information")
                .MaximumLength(20).WithMessage("Please do not enter more than 20 characters");
            RuleFor(x => x.SoldPrice).GreaterThanOrEqualTo(0).WithMessage("Please enter a number of 0 or big")
                .LessThanOrEqualTo(9999.99m).WithMessage("Please enter more than 10,000 small numbers");
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.CostPrice>x.SoldPrice)
                {
                    context.AddFailure("CostPrice", "Zehmet olmasa mehsulun maya deyerini satis deyerinden cox yazmayin");
                }
            });
        }
    }

}
