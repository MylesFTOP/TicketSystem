using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TicketSystemLibrary.Tests
{
    public class OverrideTests
    {
        private readonly PartModel part = Factory.CreatePartModel();
        private readonly PartModel duplicatePart = Factory.CreatePartModel();
        private readonly EngineerModel engineer = Factory.CreateEngineerModel();

        [Fact]
        public void PartModel_UpdateIdShouldChangeId() {
            var expected = part.PartId + 1;
            part.UpdatePartId(part.PartId + 1);
            var actual = part.PartId;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, null)]
        public void PartModel_EqualsReturnsExpectedValues(bool expected, object comparison) {
            var actual = part.Equals(comparison);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModel_EqualsShouldNotMatchDifferentTypes() {
            var expected = false;
            var actual = part.Equals(engineer);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModel_EqualsShouldMatchDifferentItemsWithSameId() {
            var expected = true;
            var actual = part.Equals(duplicatePart);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModel_EqualsOperatorOverrideShouldMatchDifferentItemsWithSameId() {
            var expected = true;
            var actual = part == duplicatePart;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModel_NotEqualsOperatorOverrideShouldConsiderDifferentItemsWithSameIdToBeEqual() {
            bool expected = false;
            bool actual = part != duplicatePart;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModel_EqualsOperatorShouldFindEqualityForNullReferences() {
            var expected = true;
            var actual = (PartModel)null == (PartModel)null;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModelEqualsOperatorShouldNotFindEqualityForOneNullReferenceOnRight() {
            var expected = false;
            var actual = part == (PartModel)null;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModelEqualsOperatorShouldNotFindEqualityForOneNullReferenceOnLeft() {
            var expected = false;
            var actual = (PartModel)null == part;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartModel_GetHashCodeShouldReturnHashCodeOfId() {
            var expected = HashCode.Combine(part.PartId);
            var actual = part.GetHashCode();
            Assert.Equal(expected, actual);
        }
    }
}
