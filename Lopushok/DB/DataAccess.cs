using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Lopushok.DB
{
    public static class DataAccess
    {
        public delegate void NewItemAddedDeledate();
        public static event NewItemAddedDeledate NewItemAddedEvent;

        public static List<Product> GetProducts() => LopushokEntities.GetContext().Product.ToList();
        public static List<ProductType> GetProductTypes() => LopushokEntities.GetContext().ProductType.ToList();
        public static List<Material> GetMaterials() => LopushokEntities.GetContext().Material.ToList();
        public static List<MaterialType> GetMaterialTypes() => LopushokEntities.GetContext().MaterialType.ToList();
        public static List<Workshop> GetWorkshops() => LopushokEntities.GetContext().Workshop.ToList();

        public static void SaveProduct(Product product)
        {
            if (!GetProducts().Any(x => x == product))
                LopushokEntities.GetContext().Product.Add(product);

            LopushokEntities.GetContext().SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static void DeleteProduct(Product product)
        {
            LopushokEntities.GetContext().Product.Remove(product);

            LopushokEntities.GetContext().SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static void DeleteProductMaterial(ProductMaterial productMaterial)
        {
            LopushokEntities.GetContext().ProductMaterial.Remove(productMaterial);
        }
    }
}
