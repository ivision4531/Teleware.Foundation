//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Teleware.Foundation.Data;

//namespace Teleware.Foundation.Command
//{
//    /// <summary>
//    /// 流程实例操作命令分派器
//    /// </summary>
//    public class CommandDispatcher
//    {
//        private readonly Dictionary<Type, ICommandHandler> _commandHandlers = new Dictionary<Type, ICommandHandler>();

//        /// <summary>
//        /// 构造方法
//        /// </summary>
//        /// <param name="commandHandlers"></param>
//        /// <param name="uow"></param>
//        public CommandDispatcher(ICommandHandler[] commandHandlers, IUnitOfWork uow)
//        {
//            InitCommandHandlers(commandHandlers, uow);
//        }

//        private void InitCommandHandlers(ICommandHandler[] commandHandlers, IUnitOfWork uow)
//        {
//            foreach (var commandHandler in commandHandlers)
//            {
//                commandHandler.CommandDispatcher = this;
//                commandHandler.UnitOfWork = uow;
//                _commandHandlers[commandHandler.CommandType] = commandHandler;
//            }
//        }

//        /// <summary>
//        /// 分派流程实例修改命令
//        /// </summary>
//        /// <param name="command">修改命令</param>
//        public Task DispatchAsync(ICommand command)
//        {
//            return DispatchCommandAsync(command);
//        }

//        /// <summary>
//        /// 分派命令以执行
//        /// </summary>
//        /// <param name="command">修改命令</param>
//        private Task DispatchCommandAsync(ICommand command)
//        {
//            var commandType = command.GetType();
//            var handler = _commandHandlers[commandType];
//            return handler.HandleAsync(command);
//        }
//    }
//}