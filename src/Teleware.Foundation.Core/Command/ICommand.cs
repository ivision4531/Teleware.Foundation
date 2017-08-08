//using System;

//namespace Teleware.Foundation.Command
//{
//    /// <summary>
//    /// 流程实例操作命令
//    /// </summary>
//    public interface ICommand
//    {
//        /// <summary>
//        /// 命令Id
//        /// </summary>
//        string Id { get; }
//    }

//    /// <summary>
//    /// 带结果流程实例操作命令
//    /// </summary>
//    /// <typeparam name="TResult">结果类型</typeparam>
//    /// <remarks>严格来说Command应当不带执行结果，所以此接口能少用就少用</remarks>
//    public interface ICommandWithResult<TResult> : ICommand
//    {
//        /// <summary>
//        /// 设置命令执行结果
//        /// </summary>
//        /// <param name="result"></param>
//        void SetCommandExecuteResult(TResult result);

//        /// <summary>
//        /// 命令执行结果
//        /// </summary>
//        TResult Result { get; }
//    }

//    /// <summary>
//    /// 流程实例操作命令基类
//    /// </summary>
//    /// <remarks>只省掉了Id的创建</remarks>
//    public abstract class CommandBase : ICommand
//    {
//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        public CommandBase()
//        {
//            Id = Guid.NewGuid().ToString();
//        }

//        /// <see cref="ICommand.Id"/>
//        public string Id
//        {
//            get;
//            private set;
//        }
//    }
//}