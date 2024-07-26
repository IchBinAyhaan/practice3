
namespace Shop
{
    internal class Shop
    {
        private List<Product> products = new List<Product>();
        public double TotalIncome { get; private set; } = 0;
        public void AddProduct(string name, double price, int count, string productType)
        {
            bool productExists = false;
            foreach (Product p in products)
            {
                if (p.Name == name)
                {
                    productExists = true;
                    break;
                }
            }
            if (productExists)
            {
                Console.WriteLine($"Product '{name}' already exists. Cannot add duplicate products.");
                return;
            }
            Product newProduct = null;
            if (productType.ToLower() == "c")
            {
                newProduct = new Coffee(name, price, count);
            }
            else if (productType.ToLower() == "t")
            {
                newProduct = new Tea(name, price, count);
            }
            else
            {
                Console.WriteLine("Invalid product type. Please enter 'c' for Coffee or 't' for Tea.");
                return;
            }
            products.Add(newProduct);
            Console.WriteLine($"Product '{name}' added successfully.");
        }

        public void BuyProduct(string name, int count)
        {
            Product product = null;
            foreach (Product p in products)
            {
                if (p.Name == name)
                {
                    product = p;
                    break; 
                }
            }
            if (product != null)
            {
                if (product.Count >= count)
                {
                    double totalPrice = product.Price * count;
                    TotalIncome += totalPrice;
                    product.Count -= count;
                    Console.WriteLine($"Ürün '{name}' başarıyla satıldı. Toplam fiyat: {totalPrice}.");
                }
                else
                {
                    Console.WriteLine($"Stokta yeterli '{name}' bulunmamaktadır.");
                }
            }
            else
            {
                Console.WriteLine($"Ürün '{name}' bulunamadı.");
            }
        }

        public void ShowAvailableProducts()
        {
            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Count: {product.Count}");
            }
        }
    }
}
