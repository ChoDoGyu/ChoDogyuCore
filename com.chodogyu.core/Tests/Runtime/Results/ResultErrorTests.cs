using System;
using CDG.Core.Results;
using NUnit.Framework;

namespace CDG.Core.Tests.Results
{
    /// <summary>
    /// ResultError의 생성 규칙과 오류 없음 상태를 검증합니다.
    /// </summary>
    public sealed class ResultErrorTests
    {
        [Test]
        public void Constructor_ValidCodeAndMessage_CreatesError()
        {
            ResultError error = new ResultError("TEST_ERROR", "Test error message.");

            Assert.AreEqual("TEST_ERROR", error.Code);
            Assert.AreEqual("Test error message.", error.Message);
        }

        [Test]
        public void Constructor_NullCode_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ResultError(null, "Test error message."));
        }

        [Test]
        public void Constructor_EmptyCode_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ResultError(string.Empty, "Test error message."));
        }

        [Test]
        public void Constructor_NullMessage_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ResultError("TEST_ERROR", null));
        }

        [Test]
        public void None_ReturnsEmptyCodeAndMessage()
        {
            Assert.AreEqual(string.Empty, ResultError.None.Code);
            Assert.AreEqual(string.Empty, ResultError.None.Message);
        }

        [Test]
        public void None_ReturnsSameInstance()
        {
            Assert.AreSame(ResultError.None, ResultError.None);
        }
    }
}