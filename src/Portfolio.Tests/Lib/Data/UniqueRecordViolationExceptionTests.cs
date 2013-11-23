using System;
using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib.Data
{
    [TestFixture]
    public class UniqueRecordViolationExceptionTests
    {
        [Test]
        public void Has_expected_unique_duplicate_key_value()
        {
            var innerException = CreateInnerException();
            var exception = new UniqueRecordViolationException(innerException);
            exception.DuplicateKeyValue.Should().Be("Meetings");
        }

        [Test]
        public void Has_expected_table()
        {
            var innerException = CreateInnerException();
            var exception = new UniqueRecordViolationException(innerException);
            exception.Table.Should().Be("dbo.Tags");
        }

        [Test]
        public void Has_expected_unique_index()
        {
            var innerException = CreateInnerException();
            var exception = new UniqueRecordViolationException(innerException);
            exception.UniqueIndex.Should().Be("IX_Tags_Description");
        }

        public static Exception CreateInnerException()
        {
            return new Exception("Cannot insert duplicate key row in object 'dbo.Tags' with unique index 'IX_Tags_Description'. The duplicate key value is (Meetings).");
        }
    }
}
