using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class LocationTests
    {
        private readonly EngineerModel engineer = Factory.CreateEngineerModel();

        [Fact]
        public void EngineerModel_UpdateBasePostcodeShouldSetBasePostcode()
        {
            var expected = "NU00 0OO";
            engineer.UpdateBasePostcode(expected);
            var actual = engineer.BasePostcode;
            Assert.Equal(expected, actual);
        }
    }
}
