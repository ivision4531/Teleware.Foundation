using System;

namespace Teleware.Foundation.Util
{
    /// <summary>
    /// 路径相关帮助类
    /// </summary>
    public static class Paths
    {
        /// <summary>
        /// 获取绝对路径
        /// </summary>
        /// <param name="absoluteBasePath">绝对路径</param>
        /// <param name="relativePath">相对路径</param>
        /// <returns></returns>
        public static string GetAbsoluteFilePath(string absoluteBasePath, string relativePath)
        {
            var p = new Uri(new Uri(absoluteBasePath), relativePath).LocalPath;
            return p;
        }
    }
}