using InBoundService.Controller;
using InBoundService.Database.Entities;
using InBoundService.Database.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class InboundOrderTest
    {
        private readonly OrderController _controller;
        private readonly IOrderRepository _service;

        public InboundOrderTest()
        {
            _service = new OrderRepositoryFake();
            _controller = new OrderController(_service);
        }

        [Fact]
        public void Test1()
        {

        }

        
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Order>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
