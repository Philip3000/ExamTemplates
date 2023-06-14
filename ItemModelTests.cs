using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.Models.Tests
{
    [TestClass()]
    public class ItemModelTests
    {
        ItemModel GoodItem = new ItemModel() { Id = 1, Name = "Chocolate", Price = 20, Description = "Quality item"};
        ItemModel BadIdItem = new ItemModel() { Id = -1, Name = "Pet toy", Price = 30, Description = "Good quality item" };
        ItemModel ShortNameItem = new ItemModel() { Id = 3, Name = "WDC", Price = 200, Description = "Semi quality item" };
        ItemModel LongNameItem = new ItemModel() { Id = 4, Name = "WoodpeckerCanChuckWood", Price = 13, Description = "X-tra quality item" };
        ItemModel NullNameItem = new ItemModel() { Id = 5, Name = null, Price = 13, Description = "X-tra quality item" };
        ItemModel BadPriceItem = new ItemModel() { Id = 6, Name = "Marabou", Price = -40, Description = "Quality item" };
        ItemModel BadDescriptionItem = new ItemModel() { Id = 7, Name = "TotalMilk", Price = 34, Description = "D" };

        [TestMethod()]
        public void ValidateIdTest()
        {
            Assert.IsNotNull(GoodItem);
            Assert.ThrowsException<ArgumentException>(() => BadIdItem.ValidateId());
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ShortNameItem.ValidateName());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => LongNameItem.ValidateName());
            Assert.ThrowsException<NullReferenceException>(() => NullNameItem.ValidateName());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            Assert.ThrowsException<ArgumentException>(() => BadPriceItem.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateDescriptionTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>  BadDescriptionItem.ValidateDescription());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            Assert.AreEqual(GoodItem.Name, "Chocolate");
        }
    }
}