using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Blazored.WebShop.Application.Interfaces.Persistence;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            // TODO: Implement data storage and remove hardcoded values
            _products = new List<Product>
            {
                new Product{ ProductId = 57011203, Brand = "Quaker", Name = "Simply Granola", Price = 34.95, ImageUrl = "/images/products/quaker_simply_granola.png", Description = "We’re adding a few favorite flavors to start your day an even better way. Satisfy your taste buds with the simply sweet and subtly tangy addition of apples, cranberries and sliced almonds. One spoonful and you’ll welcome this delicious trio to your whole-grain granola."},
                new Product{ ProductId = 57085390, Brand = "Nestlé", Name = "Lion Cereal", Price = 29.95, ImageUrl = "/images/products/nestle_lion_cereal.png", Description = "Experience the great flavor sensation of Nestle Lion wholegrain breakfast cereal. An indulgent combination of scrumptious chocolate cereal pieces combined with yummy caramel cereal pieces make LION the king of cereals! Contains 9 vitamins and minerals, including calcium and iron. It's made with 39% whole grain and is a source of fiber."},
                new Product{ ProductId = 57092365, Brand = "Kellogg's", Name = "Cornflakes", Price = 27.95, ImageUrl = "/images/products/kelloggs_cornflakes.png", Description = "Kelloggs Corn Flakes cereal is the Original & Best cereal. Every bite of these crispy, golden flakes is just as delicious as the first. You'll be on your way to a great day when you pour a bowl of Kellogg's Corn Flakes cereal into your breakfast bowl."},
                new Product{ ProductId = 57092342, Brand = "Kellogg's", Name = "Froot Loops", Price = 49.95, ImageUrl = "/images/products/kelloggs_froot_loops.png", Description = "Kellogg’s Froot Loops is packed with delicious fruity taste, fruity aroma, and bright colors. Made with whole grains and sweetened, Froot Loops cereal is a fun part of a complete breakfast."},
                new Product{ ProductId = 57092312, Brand = "Nestlé", Name = "Cheerios Original", Price = 20, ImageUrl = "/images/products/nestle_cheerios.png", Description = "Cheerios has been a family favorite for years. Its wholesome goodness is perfect for toddlers to adults and everyone in between. Made from whole grain oats, and without artificial flavors or colors, they’re naturally low in fat and cholesterol free. These wholesome little “o’s” have only one gram of sugar!"},
                new Product{ ProductId = 57094891, Brand = "Quaker", Name = "Oatmeal Squares", Price = 29.95, ImageUrl = "/images/products/quaker_oatmeal_squares.png", Description = "Don't worry, cold cereal lovers – Quaker Oats has got something deliciously crunchy for you. Our Brown Sugar Oatmeal Squares are made with whole grain Quaker oats and wheat, and are packed with the rich sweetness of brown sugar, you might never suspect they are healthy."},
                new Product{ ProductId = 57094321, Brand = "Cinnamon Toast", Name = "Cinnamon Toast Crunch - 2 Bags", Price = 99, ImageUrl = "/images/products/cinnamon_toast_crunch_double.png", Description = "An epic combination of cinnamon and sugar blasted on every square. Just pour a bowl, splash on some milk and enjoy. And don’t forget to drink the Cinnamilk, the treasured milk found at the bottom of your bowl after enjoying Cinnamon Toast Crunch. It’s so delicious you’ll want to crunch and slurp around the clock."},
                new Product{ ProductId = 57092265, Brand = "Cinnamon Toast", Name = "Chocolate Toast Crunch", Price = 50, ImageUrl = "/images/products/chocolate_toast_crunch.png", Description = "You asked, we delivered. The treasured Chocolate Toast Crunch is back by popular demand. Made with cocoa and cinnamon, this cereal delivers on the beloved cinnamon-sugar flavor combination with an epic chocolatey twist."}
            };
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            return string.IsNullOrWhiteSpace(filter) 
                ? _products 
                : _products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(x => x.ProductId == id);
        }
    }
}
