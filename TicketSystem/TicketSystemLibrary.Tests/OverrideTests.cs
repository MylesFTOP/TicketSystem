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

        [Fact]
        public void PartsModel_UpdateIdShouldChangeId() {
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
        public void PartsModel_EqualsShouldMatchDifferentItemsWithSameId() {
            var expected = true;
            var actual = part.Equals(duplicatePart);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartsModel_EqualsOperatorOverrideShouldMatchDifferentItemsWithSameId() {
            var expected = true;
            var actual = part == duplicatePart;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartsModel_NotEqualsOperatorOverrideShouldConsiderDifferentItemsWithSameIdToBeEqual() {
            bool expected = false;
            bool actual = part != duplicatePart;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartsModel_EqualsOperatorShouldFindEqualityForNullReferences() {
            var expected = true;
            var actual = (PartModel)null == (PartModel)null;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartsModelEqualsOperatorShouldNotFindEqualityForOneNullReferenceOnRight() {
            var expected = false;
            var actual = part == (PartModel)null;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartsModelEqualsOperatorShouldNotFindEqualityForOneNullReferenceOnLeft() {
            var expected = false;
            var actual = (PartModel)null == part;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartsModel_GetHashCodeShouldReturnHashCodeOfId() {
            var expected = HashCode.Combine(part.PartId);
            var actual = part.GetHashCode();
            Assert.Equal(expected, actual);
        }
    }
}
