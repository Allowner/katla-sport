using FluentValidation;

namespace KatlaSport.Services.HiveManagement
{
    public class UpdateHiveSectionProductRequestValidator : AbstractValidator<UpdateHiveSectionProductRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateHiveSectionProductRequestValidator"/> class.
        /// </summary>
        public UpdateHiveSectionProductRequestValidator()
        {
            RuleFor(r => r.ProductId).GreaterThan(0);
            RuleFor(r => r.Quantity).GreaterThan(-1);
        }
    }
}
