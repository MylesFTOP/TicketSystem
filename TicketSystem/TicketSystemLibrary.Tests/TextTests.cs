using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class TextTests
    {
        private readonly TicketModel ticket = Factory.CreateTicketModel();

        [Fact]
        public void TicketModel_UpdateTitleShouldUpdateTicketTitle()
        {
            var previous = ticket.TicketTitle;
            ticket.UpdateTitle("New title");
            var updated = ticket.TicketTitle;
            Assert.NotEqual(previous, updated);
        }
    }
}
