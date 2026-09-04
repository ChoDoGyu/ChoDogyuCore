using System;
using CDG.Core.Results;
using NUnit.Framework;

namespace CDG.Core.Tests.Results
{
    /// <summary>
    /// Result의 성공 및 실패 상태와 생성 규칙을 검증합니다.
    /// </summary>
    public sealed class ResultTests
    {
        [Test]
        public void Success_CreatesSuccessfulResult()
        {
            Result result = Result.Success();

            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.IsFailure);
            Assert.AreSame(ResultError.None, result.Error);
        }

        [Test]
        public void Failure_ValidError_CreatesFailedResult()
        {
            ResultError error = new ResultError("TEST_ERROR", "Test error message.");

            Result result = Result.Failure(error);

            Assert.IsFalse(result.IsSuccess);
            Assert.IsTrue(result.IsFailure);
            Assert.AreSame(error, result.Error);
        }

        [Test]
        public void Failure_NullError_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Result.Failure(null));
        }

        [Test]
        public void Failure_NoneError_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Result.Failure(ResultError.None));
        }
    }
}