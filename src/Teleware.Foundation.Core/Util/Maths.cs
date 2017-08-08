using System;
using Teleware.Foundation.Assertion;

namespace Teleware.Foundation.Util
{
    /// <summary>
    /// 数学相关帮助扩展
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// 将数字的小数部分四舍五入为特定位数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="digits">小数位数</param>
        /// <returns></returns>
        public static decimal ToFixed(this decimal source, int digits)
        {
            digits.ShouldBe(d => d >= 0, () => new ArgumentException("digits应大等于0", nameof(digits)));
            return Math.Round(source, digits, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 将数字的小数部分四舍五入为特定位数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="digits">小数位数</param>
        /// <returns></returns>
        public static double ToFixed(this double source, int digits)
        {
            digits.ShouldBe(d => d >= 0, () => new ArgumentException("digits应大等于0", nameof(digits)));
            return Math.Round(source, digits, MidpointRounding.AwayFromZero);
        }
    }
}

//using System;

//namespace Teleware.Foundation.Util
//{
//    /// <summary>
//    /// 数学相关帮助类
//    /// </summary>
//    public static class Maths
//    {
//        /// <summary>
//        ///  平方米转公顷
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static decimal ConvertToHectare(decimal value)
//        {
//            return Math.Round(value / 10000, 4, MidpointRounding.AwayFromZero);
//        }

//        /// <summary>
//        /// 平方米转公顷
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static double ConvertToHectare(double value)
//        {
//            return Math.Round(value / 10000, 4, MidpointRounding.AwayFromZero);
//        }

//        /// <summary>
//        /// 计算面积
//        /// </summary>
//        public static double CalculateRang(double x1, double y1, double x2, double y2)
//        {
//            double rang = Math.Pow((x1 - x2), 2.0) + Math.Pow((y1 - y2), 2.0);
//            rang = Math.Pow(rang, 0.5);
//            return rang;
//        }

//        /// <summary>
//        /// 经纬度转度分秒
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static string JWDToDMS(decimal value)
//        {
//            var d = (int)value;
//            var m = (int)((value - d) * 60);
//            var s = (int)(((value - d) * 60 - m) * 60);
//            return string.Format("{0}°{1}′{2}″", d, m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
//        }

//        /// <summary>
//        /// 将度分秒转为经纬度
//        /// </summary>
//        /// <returns></returns>
//        public static decimal DMSToJWD(decimal dms)
//        {
//            DMSDegreeToDegree(dms, out int d, out int m, out int s);
//            return DMSToJWD(d, m, s);
//        }

//        /// <summary>
//        /// 将度分秒转为经纬度
//        /// </summary>
//        /// <returns></returns>
//        public static decimal DMSToJWD(string dms)
//        {
//            var dmsArr = dms.Split(new char[3] { '°', '′', '″' });
//            var dblDegree = Convert.ToDecimal(dmsArr[0]);

//            dblDegree += Convert.ToDecimal(dmsArr[1]) / 60M;
//            dblDegree += Convert.ToDecimal(dmsArr[2]) / 3600M;

//            return dblDegree;
//        }

//        /// <summary>
//        /// 将度分秒转为经纬度
//        /// </summary>
//        /// <returns></returns>
//        public static decimal DMSToJWD(int degree, int minute, int second)
//        {
//            decimal dblDegree = degree;
//            dblDegree += Convert.ToDecimal(minute) / 60M;
//            dblDegree += Convert.ToDecimal(second) / 3600M;
//            return dblDegree;
//        }

//        /// <summary>
//        /// 度分秒的十进制转字符串，116.6756 => 117°07′56″
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static string DMSToString(decimal value)
//        {
//            DMSDegreeToDegree(value, out int d, out int m, out int s);
//            return string.Format("{0}°{1}′{2}″", d, m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
//        }

//        /// <summary>
//        /// 将度分秒转为十进制度
//        /// </summary>
//        /// <returns></returns>
//        public static decimal DMSDegreeToDecimalDegree(decimal dms)
//        {
//            DMSDegreeToDegree(dms, out int d, out int m, out int s);
//            return DMSToJWD(d, m, s);
//        }

//        /// <summary>
//        /// 度分秒的十进制转度分秒116.6756 => 117.0756
//        /// </summary>
//        /// <param name="dms"></param>
//        /// <param name="degree"></param>
//        /// <param name="minute"></param>
//        /// <param name="second"></param>
//        public static void DMSDegreeToDegree(decimal dms, out int degree, out int minute, out int second)
//        {
//            //转换成decimal才能保证计算的精度
//            decimal dbl;
//            degree = (int)dms;
//            dbl = dms - degree;
//            minute = (int)(dbl * 100);
//            dbl = dbl * 100 - minute;
//            second = (int)(dbl * 100);
//            if (minute >= 60)
//            {
//                degree++;
//                minute -= 60;
//            }
//            if (second >= 60)
//            {
//                minute++;
//                second -= 60;
//            }
//        }
//    }
//}