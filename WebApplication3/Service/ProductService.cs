using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Repository;

namespace WebApplication3.Service
{
    public class ProductService
    {
        public ProductRepository _productrepository = new ProductRepository();


        public Product[] Get(string nome = "", string filtro = "", string sort = "", int page = 0, int size = 5)
        {
            Product[] products = _productrepository.products;
            if (filtro != "" || nome != "")
            {
               products = GetFilter(products, filtro, nome);

            }
            if (sort == "preco")
            {
                products = getSortPrice(products);
            }
            return GetPagination(products, page,size);
        }
    
        public Product[] GetPagination(Product[] array, int page, int pageSize)
        {
            Product[] products = array.Skip((page -1)*pageSize).Take(pageSize).ToArray();
            return products;
        }




        public Product[] GetFilter(Product[] array, string filter, string name)
        {
            if (name != "")
            {
                Product[] productsByName = array.Where(d => d.Name.ToLower().Contains(name.ToLower())).ToArray();
                if (filter != "")
                {
                    Product[] productsByNameAndFilter = productsByName.Where(d => d.Description.ToLower().Contains(filter)).ToArray();
                    return productsByNameAndFilter;
                }
                else
                {
                    return productsByName;
                }
            }
            else
            {
                Product[] productsByFilter = array.Where(d => d.Description.ToLower().Contains(filter.ToLower())).ToArray();
                return productsByFilter;
            }

        }

        public Product[] getSortPrice(Product[] products)
        {
           
            return products.OrderBy(b=>b.Price).ToArray();
        }

    }
}
