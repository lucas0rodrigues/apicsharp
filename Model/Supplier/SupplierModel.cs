using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace apicsharp.Model.Supplier
{
    public class SupplierModel
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public SupplierModel()
        {
        }

        public SupplierModel(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}
