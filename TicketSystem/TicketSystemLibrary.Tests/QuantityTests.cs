using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class QuantityTests
    {
        private readonly PartModel part = new PartModel();

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
    }
}
