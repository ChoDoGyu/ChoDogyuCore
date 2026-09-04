using System;

namespace CDG.Core.Results
{
    public sealed class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public ResultError Error { get; }

        private Result(bool isSuccess, ResultError error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success()
        {
            return new Result(true, ResultError.None);
        }

        public static Result Failure(ResultError error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            if (ReferenceEquals(error, ResultError.None))
            {
                throw new ArgumentException("Failure result requires an error.", nameof(error));
            }

            return new Result(false, error);
        }
    }
}