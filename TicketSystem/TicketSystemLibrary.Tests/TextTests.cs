﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class TextTests
    {
        private readonly EngineerModel engineer = Factory.CreateEngineerModel();
        private readonly TicketModel ticket = Factory.CreateTicketModel();

        [Fact]
        public void EngineerModel_UpdateFirstNameShouldUpdateFirstName()
        {
            var previous = engineer.FirstName;
            engineer.UpdateFirstName("New name");
            var updated = engineer.FirstName;
            Assert.NotEqual(previous, updated);
        }
        
        [Fact]
        public void EngineerModel_UpdateLastNameShouldUpdateLastName()
        {
            var previous = engineer.LastName;
            engineer.UpdateLastName("New name");
            var updated = engineer.LastName;
            Assert.NotEqual(previous, updated);
        }
        
        [Fact]
        public void EngineerModel_UpdateHomePostcodeShouldUpdateHomePostcode()
        {
            var previous = engineer.HomePostcode;
            engineer.UpdateHomePostcode("NU00 0OO");
            var updated = engineer.HomePostcode;
            Assert.NotEqual(previous, updated);
        }

        [Fact]
        public void TicketModel_UpdateTitleShouldUpdateTicketTitle()
        {
            var previous = ticket.TicketTitle;
            ticket.UpdateTitle("New title");
            var updated = ticket.TicketTitle;
            Assert.NotEqual(previous, updated);
        }

        [Fact]
        public void TicketModel_UpdateTitleShouldUpdateTicketUpdatedDateTime()
        {
            var previous = ticket.TicketUpdatedDateTime;
            ticket.UpdateTitle("Test text");
            var updated = ticket.TicketUpdatedDateTime;
            Assert.NotEqual(previous, updated);
        }

        [Fact]
        public void TicketModel_UpdateDescriptionShouldUpdateTicketDescription()
        {
            var previous = ticket.TicketDescription;
            ticket.UpdateDescription("New description");
            var updated = ticket.TicketDescription;
            Assert.NotEqual(previous, updated);
        }

        [Fact]
        public void TicketModel_UpdateDescriptionShouldUpdateTicketUpdatedDateTime()
        {
            var previous = ticket.TicketUpdatedDateTime;
            ticket.UpdateDescription("Test text");
            var updated = ticket.TicketUpdatedDateTime;
            Assert.NotEqual(previous, updated);
        }
    }
}
