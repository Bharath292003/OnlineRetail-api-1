using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using onlineRetail.Controllers;
using onlineRetail.Model;
using onlineRetail.Repository;
using onlineRetail.Repository.IRepository;

namespace OnlineRetailAPI.Test
{
    public class CustomerControllerTest
    {
        CustomerController _controller;
        ICustomerRepository _customerRepository;
        public CustomerControllerTest()
        {
            _customerRepository = A.Fake<ICustomerRepository>();
            _controller = new CustomerController(_customerRepository);
        }
        //[Fact]
        //public void GetAllTest()
        //{
        //    //act
        //    var result = _controller.Getcustomer();
        //    //assert
        //    Assert.IsType<OkObjectResult>(result.Result as OkObjectResult);
        //}
        [Fact]
        public async void GetAllTest2() 
        {
            var result = await _customerRepository.GetAll();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
        
    }
}