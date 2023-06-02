using Xunit;
using TestingApp.Functionality;

namespace TestingApp.Test{
    public class UserManagementTest{

        [Fact]
        public void Add_CreateUser(){
            //Arrange
            var userManagement = new UserManagement();
            
            //Act
            userManagement.Add(new ("Samuel", "Peralta"));
            
            //Assert
            var savedUser = Assert.Single(userManagement.AllUsers());
            Assert.NotNull(savedUser); // checking that the user management list is not empty
            Assert.Equal("Samuel", savedUser.UserName);
            Assert.Equal("Peralta", savedUser.LastName);
            Assert.False(savedUser.VerifiedEmail);
        }

        [Fact]

        public void Update_MobileNumber(){
       
           //Arrange
            var userManagement = new UserManagement();
            
            //Act
            userManagement.Add(new ("Samuel", "Peralta"));
            
            var firstUser = userManagement.AllUsers().First();
            firstUser.Phone = "+4440000022";

            userManagement.UpdatePhone(firstUser);
            
            //Assert
            var savedUser = Assert.Single(userManagement.AllUsers());
            Assert.NotNull(savedUser);
            Assert.Equal("+4440000022", savedUser.Phone);
        }
    }
}