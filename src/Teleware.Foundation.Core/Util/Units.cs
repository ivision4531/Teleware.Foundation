using System;

namespace Teleware.Foundation.Util
{
    /// <summary>
    /// 单位定义
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// 公顷
        /// </summary>
        Hectare,

        /// <summary>
        /// 亩
        /// </summary>
        Mu
    }

    /// <summary>
    /// 单位相关帮助类
    /// </summary>
    public static class Units
    {
        private const double MU_SM_RATIO = (1 / 15.0 * 10000);
        /// <summary>
        /// 平方米转公顷
        /// </summary>
        /// <param name="squareMeter">平方米</param>
        /// <returns></returns>
        public static double ToHectare(double squareMeter)
        {
            var result = squareMeter / 10000;
            return result;
        }

        /// <summary>
        /// 平方米转亩
        /// </summary>
        /// <param name="squareMeter">平方米</param>
        /// <returns></returns>

        public static double ToMu(double squareMeter)
        {
            var result = (squareMeter / MU_SM_RATIO);
            return Math.Round(result * 10000) / 10000;
        }

        /// <summary>
        /// 亩转平方米转
        /// </summary>
        /// <param name="mu">平方米</param>
        /// <returns></returns>
        public static double MuToSquareMeter(double mu)
        {
            var result = mu * MU_SM_RATIO;
            return result;
        }

        /// <summary>
        /// 公顷转平方米
        /// </summary>
        /// <param name="hectare">公顷</param>
        /// <returns></returns>

        public static double HectareToSquareMeter(double hectare)
        {
            var result = hectare * 10000;
            return result;
        }
    }
}