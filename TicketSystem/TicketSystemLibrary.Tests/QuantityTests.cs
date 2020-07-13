using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class QuantityTests
    {
        private readonly PartModel part = Factory.CreatePartModel();
        private readonly EngineerModel engineer = Factory.CreateEngineerModel();
        private readonly List<PartModel> partsToAdd = Factory.CreatePartModelList();

        [Fact]
        public void PartModel_AddToStockShouldIncreaseQuantity() {
            var expected = 3;

            part.AddToStock(3);
            var actual = part.Quantity;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModel_RemoveFromStockShouldDecreaseQuantity() {
            part.Quantity = 3;
            var expected = 0;

            part.RemoveFromStock(3);
            var actual = part.Quantity;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EngineerModel_AddPartsToStockShouldIncreaseListLength() {
            var expected = engineer.PartsInStock.Count + 1;
            part.Quantity = 1;
            partsToAdd.Add(part);
            engineer.AddPartsToStock(partsToAdd);
            var actual = engineer.PartsInStock.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EngineerModel_ZeroQuantityPartShouldBeRemovedFromList() {
            var expected = false;
            part.Quantity = 0;
            partsToAdd.Add(part);
            engineer.AddPartsToStock(partsToAdd);
            var actual = engineer.PartsInStock.Contains(part);

            Assert.Equal(expected, actual);
        }
    }
}
