using TestingApp.Functionality;
using System;
using Xunit;
using Moq;

namespace TestingApp.Test{

    public class ShoppingCartTest{
        public readonly Mock<IDbService> _dbServiceMock = new();
        [Fact]
        public void Add_Product_Success(){

            //Given
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
            
            //When
            var product = new Product(1,"shoes",150);
            var result = shoppingCart.AddProduct(product);

            //Then
            Assert.True(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once());
        }

        [Fact]
        public void Add_Product_Failure_DueToInvalidPayload(){
             //Given

            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
            
            //When
            var result = shoppingCart.AddProduct(null);

            //Then
            Assert.False(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Never());
        }

        [Fact]
        public void RemoveProduct_Success (){
           //Given
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
            
            //When
            var product = new Product(1,"shoes",150);
            var result = shoppingCart.AddProduct(product);
            var deleteResult = shoppingCart.DeleteProduct(product.Id);


            //Then
            Assert.True(deleteResult);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once());
        }
    }
}