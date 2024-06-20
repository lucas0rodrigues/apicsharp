using System.ComponentModel.DataAnnotations;

namespace apicsharp.Model.Category
{
    public class CategoryModel
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public CategoryModel()
        {
        }

        public CategoryModel(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}
