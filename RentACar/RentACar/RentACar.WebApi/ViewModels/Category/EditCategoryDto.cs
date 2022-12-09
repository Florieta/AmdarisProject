using System.ComponentModel.DataAnnotations;

namespace RentACar.WebApi.ViewModels.Category
{
    public class EditCategoryDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string CategoryName { get; set; } = null!;
    }
}
