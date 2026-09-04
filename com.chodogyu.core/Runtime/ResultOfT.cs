using System;

namespace CDG.Core.Results
{
    /// <summary>
    /// 성공 시 지정한 타입의 값을 함께 반환하는 작업의 성공 또는 실패 결과를 나타냅니다.
    /// 성공한 경우 <see cref="Value"/>를 사용하고, 실패한 경우 <see cref="Error"/>를 통해 원인을 확인할 수 있습니다.
    /// </summary>
    /// <typeparam name="T">성공했을 때 반환할 값의 타입입니다.</typeparam>
    public sealed class Result<T>
    {
        private readonly T _value;

        /// <summary>
        /// 작업이 성공했는지를 나타냅니다.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// 작업이 실패했는지를 나타냅니다.
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// 작업의 오류 정보입니다.
        /// 성공한 경우 <see cref="ResultError.None"/>입니다.
        /// </summary>
        public ResultError Error { get; }

        /// <summary>
        /// 성공한 작업의 결과 값을 반환합니다.
        /// 실패 상태에서 접근하면 <see cref="InvalidOperationException"/>이 발생합니다.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// 실패 상태의 Result에서 Value에 접근한 경우 발생합니다.
        /// </exception>
        public T Value
        {
            get
            {
                if (IsFailure)
                {
                    throw new InvalidOperationException("Cannot access the value of a failed result.");
                }

                return _value;
            }
        }

        private Result(bool isSuccess, T value, ResultError error)
        {
            IsSuccess = isSuccess;
            _value = value;
            Error = error;
        }

        /// <summary>
        /// 지정한 값을 가진 성공 결과를 생성합니다.
        /// 참조 타입의 경우 null도 성공값으로 허용합니다.
        /// </summary>
        /// <param name="value">성공 시 반환할 값입니다.</param>
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, ResultError.None);
        }

        /// <summary>
        /// 지정한 오류 정보를 가진 실패 결과를 생성합니다.
        /// null 또는 <see cref="ResultError.None"/>은 사용할 수 없습니다.
        /// </summary>
        /// <param name="error">실패 원인을 나타내는 오류 정보입니다.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="error"/>가 null인 경우 발생합니다.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="error"/>가 <see cref="ResultError.None"/>인 경우 발생합니다.
        /// </exception>
        public static Result<T> Failure(ResultError error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            if (ReferenceEquals(error, ResultError.None))
            {
                throw new ArgumentException("Failure result requires an error.", nameof(error));
            }

            return new Result<T>(false, default, error);
        }
    }
}