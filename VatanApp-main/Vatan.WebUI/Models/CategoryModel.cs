using System.ComponentModel.DataAnnotations;

namespace Vatan.WebUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori ismi boş bırakılamaz!")]
        [DataType(DataType.Text)]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "Kategori açıklaması boş bırakılamaz!")]
        [DataType(DataType.Text)]
        public string? CategoryDescription { get; set; }
    }
}
