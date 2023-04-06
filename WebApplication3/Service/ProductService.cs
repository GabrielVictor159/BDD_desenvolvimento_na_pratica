using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    public class ProductService
    {
        public ProductRepository _productrepository = new ProductRepository();

        public Product[] Get(string name = null, string Description = null,
            int id = -1, double price = -1.00,
            string sort = "", int page = 0, int size = 5)
        {
            Product[] products = _productrepository.products;

            products = GetFilter(products, Description, name, id, price);
            if (sort == "preco")
            {
                products = getSortPrice(products);
            }
            return GetPagination(products, page, size);
        }

        public Product[] GetPagination(Product[] array, int page, int pageSize)
        {
            Product[] products = array.Skip((page - 1) * pageSize).Take(pageSize).ToArray();
            return products;
        }

        public Product[] GetFilter(Product[] array, string description, string name, int id, double price)
        {
            Product[] novoArray = array;
            if (name != null)
            {
                novoArray = novoArray.Where(d => d.Name.ToLower().Contains(name.ToLower())).ToArray();
            }
            if (description != null)
            {
                novoArray = novoArray.Where(d => d.Description.ToLower().Contains(description.ToLower())).ToArray();
            }
            if (id != -1)
            {
                novoArray = novoArray.Where(d => d.Id == id).ToArray();
            }
            if (price != -1)
            {
                novoArray = novoArray.Where(d => d.Price == price).ToArray();
            }
            return novoArray;
        }

        public Product[] getSortPrice(Product[] products)
        {
            return products.OrderBy(b => b.Price).ToArray();
        }
    }
}
