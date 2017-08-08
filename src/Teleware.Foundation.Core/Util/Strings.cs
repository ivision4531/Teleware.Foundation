namespace Teleware.Foundation.Util
{
    /// <summary>
    /// 字符串相关帮助类
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// 返回前<paramref name="length"/>个字符组成的字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string TruncateLeft(string input, int length)
        {
            if (string.IsNullOrEmpty(input) || length <= 0 || input.Length <= length) return input;
            return input.Substring(0, length);
        }

        /// <summary>
        /// 返回最后<paramref name="length"/>个字符组成的字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string TruncateRight(string input, int length)
        {
            if (string.IsNullOrEmpty(input) || length <= 0 || input.Length <= length) return input;
            return input.Substring(input.Length - length);
        }
    }
}