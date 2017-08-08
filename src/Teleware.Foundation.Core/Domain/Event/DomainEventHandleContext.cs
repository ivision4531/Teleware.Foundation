//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Teleware.Foundation.Command;
//using Teleware.Foundation.Data;

//namespace Teleware.Foundation.Domain.Event
//{
//    /// <summary>
//    /// 领域事件处理上下文
//    /// </summary>
//    public class DomainEventHandleContext
//    {
//        private DomainEventHandleContext(CommandDispatcher dispatcher, IUnitOfWork uow)
//        {
//            Dispatcher = dispatcher;
//            UnitOfWork = uow;
//        }

//        /// <summary>
//        /// 当前命令分派器
//        /// </summary>
//        public CommandDispatcher Dispatcher
//        {
//            get;
//            set;
//        }

//        /// <summary>
//        /// 当前工作单元
//        /// </summary>
//        public IUnitOfWork UnitOfWork { get; set; }

//        /// <summary>
//        /// 创建 <see cref="ICommandHandler"/> 的领域事件处理上下文
//        /// </summary>
//        /// <param name="handler">当前CommandHandler</param>
//        /// <returns></returns>
//        public static DomainEventHandleContext FromCommandHandler(ICommandHandler handler)
//        {
//            return new DomainEventHandleContext(handler.CommandDispatcher, handler.UnitOfWork);
//        }

//        /// <summary>
//        /// 创建 <see cref="ICommandHandler"/> 的领域事件处理上下文, Dispatcher与UnitOfWork为null
//        /// </summary>
//        /// <returns><see cref="EmptyDomainEventHandleContext"/></returns>
//        public static DomainEventHandleContext Empty()
//        {
//            return new EmptyDomainEventHandleContext();
//        }

//        /// <summary>
//        /// Dispatcher与UnitOfWork为null的领域事件处理上下文
//        /// </summary>
//        public class EmptyDomainEventHandleContext : DomainEventHandleContext
//        {
//            public EmptyDomainEventHandleContext() : base(null, null)
//            {
//            }
//        }
//    }
//}