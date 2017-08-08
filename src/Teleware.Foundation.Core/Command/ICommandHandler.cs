//using System;
//using System.Threading.Tasks;
//using Teleware.Foundation.Data;
//using Teleware.Foundation.Domain.Event;

//namespace Teleware.Foundation.Command
//{
//    /// <summary>
//    /// Command处理器
//    /// </summary>
//    public interface ICommandHandler
//    {
//        /// <summary>
//        /// Command分派器
//        /// </summary>
//        CommandDispatcher CommandDispatcher { get; set; }

//        /// <summary>
//        /// 工作单元
//        /// </summary>
//        IUnitOfWork UnitOfWork { get; set; }

//        /// <summary>
//        /// 目标Command类型
//        /// </summary>
//        Type CommandType { get; }

//        /// <summary>
//        /// 处理Command
//        /// </summary>
//        /// <param name="command">Command</param>
//        Task HandleAsync(ICommand command);
//    }

//    /// <summary>
//    /// Command处理器基类
//    /// </summary>
//    public abstract class AbstractCommandHandler<TCommand> : ICommandHandler
//        where TCommand : ICommand
//    {
//        /// <inheritdoc/>
//        public CommandDispatcher CommandDispatcher { get; set; }

//        /// <inheritdoc/>
//        public IUnitOfWork UnitOfWork { get; set; }

//        /// <inheritdoc/>
//        public Type CommandType
//        {
//            get
//            {
//                return typeof(TCommand);
//            }
//        }

//        /// <inheritdoc/>
//        public Task HandleAsync(ICommand command)
//        {
//            return HandleCommandAsync((TCommand)command);
//        }

//        /// <summary>
//        /// 处理Command
//        /// </summary>
//        /// <param name="command"></param>
//        protected abstract Task HandleCommandAsync(TCommand command);

//        /// <summary>
//        /// 发送领域事件
//        /// </summary>
//        /// <param name="postBox"></param>
//        /// <param name="messenger"></param>
//        protected Task PostEventsAsync(DomainEventPostBox postBox, DomainEventMessenger messenger)
//        {
//            return postBox.DeliverAllAsync(messenger);
//        }
//    }
//}