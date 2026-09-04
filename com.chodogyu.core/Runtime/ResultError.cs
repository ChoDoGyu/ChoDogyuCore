using System;

namespace CDG.Core.Results
{
    /// <summary>
    /// 작업이 실패했을 때 실패 원인을 나타내는 오류 정보입니다.
    /// 실제 오류 코드의 정의는 Core가 아닌 각 패키지 또는 사용하는 프로젝트가 담당합니다.
    /// </summary>
    public sealed class ResultError
    {
        /// <summary>
        /// 오류가 존재하지 않음을 나타내는 특별한 값입니다.
        /// 성공한 Result의 Error 값으로 사용됩니다.
        /// </summary>
        public static ResultError None { get; } = new ResultError();

        /// <summary>
        /// 오류를 식별하기 위한 코드입니다.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// 오류에 대한 설명 메시지입니다.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// 지정한 오류 코드와 메시지를 사용하여 오류 정보를 생성합니다.
        /// Code는 null 또는 빈 문자열일 수 없으며, Message는 null일 수 없습니다.
        /// </summary>
        /// <param name="code">오류를 식별하기 위한 코드입니다.</param>
        /// <param name="message">오류에 대한 설명 메시지입니다.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="code"/>가 null 또는 빈 문자열인 경우 발생합니다.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="message"/>가 null인 경우 발생합니다.
        /// </exception>
        public ResultError(string code, string message)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentException("Error code cannot be null or empty.", nameof(code));
            }

            Message = message ?? throw new ArgumentNullException(nameof(message));
            Code = code;
        }

        private ResultError()
        {
            Code = string.Empty;
            Message = string.Empty;
        }
    }
}