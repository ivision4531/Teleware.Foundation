using System;
using System.Diagnostics;

namespace Teleware.Foundation.Diagnostics
{
    /// <summary>
    /// 耗时检测辅助
    /// </summary>
    /// <example>
    /// <code>
    /// using(ElapseTimeEvaluator.EvaluateUsedTime("block1",(msg)=>Console.WriteLine(msg)){
    ///     //...
    /// }
    /// </code>
    /// </example>
    public static class ElapseTimeEvaluator
    {
        /// <summary>
        /// 封装对计时器的常用操作，需要放在using包裹中以释放计时器。只在调试时有效
        /// </summary>
        /// <param name="stopwatchName">计时器名</param>
        /// <param name="output">输出方式</param>
        /// <returns>计时结束后Dispose掉就对了</returns>
        public static IDisposable EvaluateUsedTime(string stopwatchName, Action<string> output = null)
        {
            return new StopwatchWrapper(stopwatchName, output);
        }

        /// <summary>
        /// 封装对计时器的常用操作，需要放在using包裹中以释放计时器。只在调试时有效
        /// </summary>
        /// <param name="output">耗时</param>
        /// <returns>计时结束后Dispose掉就对了</returns>
        public static IDisposable EvaluateUsedTime(Action<TimeSpan> output)
        {
            return new StopwatchWrapper(output);
        }

        internal class StopwatchWrapper : IDisposable
        {
            private Action<string> _output1;
            private Action<TimeSpan> _output2;
            private Stopwatch _stopwatch;

            private string _stopwatchName;

            public StopwatchWrapper(string stopwatchName, Action<string> output = null)
            {
                _output1 = output;
                InitStopwatch(stopwatchName);
            }

            public StopwatchWrapper(Action<TimeSpan> output)
            {
                _output2 = output;
                InitStopwatch();
            }

            public void Dispose()
            {
                StopStopwatch();
            }

            private void InitStopwatch(string stopwatchName = null)
            {
                _stopwatchName = stopwatchName;
                _stopwatch = Stopwatch.StartNew();
            }

            private void StopStopwatch()
            {
                _stopwatch.Stop();
                if (_output1 != null)
                {
                    string message = string.Format("计时器 {0} 共耗时 {1}毫秒", _stopwatchName, _stopwatch.ElapsedMilliseconds);
                    _output1(message);
                }
                else if (_output2 != null)
                {
                    _output2(_stopwatch.Elapsed);
                }
                else
                {
                    string message = string.Format("计时器 {0} 共耗时 {1}毫秒", _stopwatchName, _stopwatch.ElapsedMilliseconds);
                }
            }
        }
    }
}