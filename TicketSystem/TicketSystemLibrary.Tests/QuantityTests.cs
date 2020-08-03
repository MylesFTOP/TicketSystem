using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace TicketSystemLibrary.Tests
{
    public class QuantityTests
    {
        private readonly PartModel part = Factory.CreatePartModel();
        private readonly PartModel duplicatePart = Factory.CreatePartModel();
        private readonly PartModel distinctPart = Factory.CreatePartModel();
        private readonly EngineerModel engineer = Factory.CreateEngineerModel();
        private readonly TaskModel task = Factory.CreateTaskModel();
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
        public void PartsModel_RemovingMorePartsThanArePresentShouldThrowException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => part.RemoveFromStock(part.Quantity + 1));
        }

        [Fact]
        public void TaskModel_UpdatePartsUsedShouldUpdatePartsUsed() {
            bool expected = true;
            partsToAdd.Add(part);
            task.UpdatePartsUsed(partsToAdd);
            bool actual = task.PartsUsed.Contains(part);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TaskModel_UpdatePartsRequiredShouldUpdatePartsRequired() {
            bool expected = true;
            partsToAdd.Add(part);
            task.UpdatePartsRequired(partsToAdd);
            bool actual = task.PartsRequired.Contains(part);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TaskModel_CompleteTaskShouldUpdatePartsUsed() {
            bool expected = true;
            partsToAdd.Add(part);
            task.CompleteTask(engineer, partsToAdd);
            bool actual = task.PartsUsed.Contains(part);
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
        public void EngineerModel_AddingDuplicatePartsToStockShouldNotIncreaseListLength() {
            part.Quantity = 1;
            partsToAdd.Add(part);
            engineer.AddPartsToStock(partsToAdd);
            var expected = engineer.PartsInStock.Count;

            partsToAdd.Add(part);
            engineer.AddPartsToStock(partsToAdd);
            var actual = engineer.PartsInStock.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EngineerModel_AddPartsToStockShouldIncreaseQuantity() {
            var expected = part.Quantity;
            part.Quantity = 1;
            partsToAdd.Add(part);
            engineer.AddPartsToStock(partsToAdd);
            var actual = part.Quantity;

            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void EngineerModel_RemovePartsFromStockShouldDecreaseQuantity() {
            part.Quantity = 1;
            var expected = part.Quantity - 1;
            engineer.PartsInStock.Add(part);

            part.Quantity = 1;
            partsToAdd.Add(part);
            engineer.RemovePartsFromStock(partsToAdd);
            var actual = engineer.PartsInStock.Where(x => x.PartId == part.PartId).Sum(x => x.Quantity);
            
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

        [Fact]
        public void PartsHandler_InvertStockQuantitiesShouldReturnOppositeSign() {
            part.Quantity = 3;
            var expected = -part.Quantity;
            partsToAdd.Add(part);

            partsToAdd.InvertStockQuantities();
            var actual = part.Quantity;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EngineerModel_DetermineRequiredPartsShouldReturnListOfPartsFromLinkedTasks() {
            var expected = 1;
            partsToAdd.Add(part);
            task.UpdatePartsRequired(partsToAdd);

            task.ScheduleTaskToEngineer(engineer, DateTime.UtcNow);
            var actual = engineer.DetermineRequiredPartsForScheduledTasks().Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartsHandler_ConsolidateDuplicateEntriesShouldReduceNumberOfEntries() {
            part.Quantity = 1;
            partsToAdd.Add(part);
            duplicatePart.Quantity = 1;
            partsToAdd.Add(duplicatePart);
            var expected = partsToAdd.Count - 1;

            partsToAdd.ConsolidateDuplicateEntries();
            var actual = partsToAdd.Count;

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Next step after determining parts required for scheduled tasks")]
        public void PartsHandler_ConsolidateDuplicateEntriesShouldIncreaseQuantityAfterConsolidation() {

        }

        [Fact(Skip = "Next step after consolidating duplicates in lists")]
        public void TaskModel_ScheduleTaskToEngineerShouldProvidePartsThatNeedOrdering() {
            //var expected = 1;

            // var actual = ;
            // Assert.Equal(expected, actual);
        }
    }
}
