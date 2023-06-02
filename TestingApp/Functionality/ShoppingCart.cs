namespace TestingApp.Functionality{

    public interface IDbService{
        bool SaveItemToShoppingCart(Product? prod);
        bool RemoteItemFromCart(int? ProducId);
    }

    public record Product(int Id, string Name, double Price);

    public class ShoppingCart{
        private readonly IDbService _dbService;

        public ShoppingCart(IDbService dbService){
            _dbService = dbService;
        }

        public bool AddProduct(Product? product){
            if(product == null)
                return false;
            if(product.Id == 0)
                return false;
            _dbService.SaveItemToShoppingCart(product);
            return true;
        }

        public bool DeleteProduct(int? id){
            if(id == null)
                return false;
            if(id == 0)
                return false;
            
            _dbService.RemoteItemFromCart((id));
            return true;
        }
    }
}