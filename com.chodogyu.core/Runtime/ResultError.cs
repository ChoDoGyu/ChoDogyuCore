using System;

namespace CDG.Core.Results
{
    public sealed class ResultError
    {
        public static ResultError None { get; } = new ResultError(string.Empty, string.Empty, true);

        public string Code { get; }
        public string Message { get; }

        public ResultError(string code, string message)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentException("Error code cannot be null or empty.", nameof(code));
            }

            Message = message ?? throw new ArgumentNullException(nameof(message));
            Code = code;
        }

        private ResultError(string code, string message, bool isNone)
        {
            Code = code;
            Message = message;
        }
    }
}