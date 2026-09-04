using System;
using CDG.Core.Results;
using NUnit.Framework;

namespace CDG.Core.Tests.Results
{
    /// <summary>
    /// Result<T>의 성공값, 실패 상태와 Value 접근 규칙을 검증합니다.
    /// </summary>
    public sealed class ResultOfTTests
    {
        [Test]
        public void Success_ValueType_CreatesSuccessfulResult()
        {
            Result<int> result = Result<int>.Success(10);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.IsFailure);
            Assert.AreEqual(10, result.Value);
            Assert.AreSame(ResultError.None, result.Error);
        }

        [Test]
        public void Success_ReferenceType_CreatesSuccessfulResult()
        {
            object value = new object();

            Result<object> result = Result<object>.Success(value);

            Assert.IsTrue(result.IsSuccess);
            Assert.AreSame(value, result.Value);
            Assert.AreSame(ResultError.None, result.Error);
        }

        [Test]
        public void Success_NullValue_AllowsSuccessfulResult()
        {
            Result<string> result = Result<string>.Success(null);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsFalse(result.IsFailure);
            Assert.IsNull(result.Value);
            Assert.AreSame(ResultError.None, result.Error);
        }

        [Test]
        public void Failure_ValidError_CreatesFailedResult()
        {
            ResultError error = new ResultError("TEST_ERROR", "Test error message.");

            Result<int> result = Result<int>.Failure(error);

            Assert.IsFalse(result.IsSuccess);
            Assert.IsTrue(result.IsFailure);
            Assert.AreSame(error, result.Error);
        }

        [Test]
        public void Failure_ValueAccess_ThrowsInvalidOperationException()
        {
            ResultError error = new ResultError("TEST_ERROR", "Test error message.");
            Result<int> result = Result<int>.Failure(error);

            Assert.Throws<InvalidOperationException>(() =>
            {
                int value = result.Value;
            });
        }

        [Test]
        public void Failure_NullError_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Result<int>.Failure(null));
        }

        [Test]
        public void Failure_NoneError_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Result<int>.Failure(ResultError.None));
        }
    }
}