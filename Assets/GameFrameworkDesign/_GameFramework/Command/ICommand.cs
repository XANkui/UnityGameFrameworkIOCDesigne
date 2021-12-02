
namespace GameFrameworkDesign {

    /// <summary>
    /// ICommand 不能有状态
    ///   ICanGetSystem, ICanGetModel, ICanGetUtility，ICanSendEvent,ICanSendCommand，ICanSendQuery 
    ///   使用规则，使得继承类可以获取 System，Model 和 Utility，SendEvent,SendCommand,SendQuery
    /// </summary>
    public interface ICommand :IBelongToArchitecture,ICanSetArchitecture, ICanGetSystem, ICanGetModel, ICanGetUtility, ICanSendEvent, ICanSendCommand,ICanSendQuery
    {
		void Execute();
	}

	public abstract class AbstractCommand : ICommand {

        private IArchitecture mArchitecture;
        void ICommand.Execute()
        {
            OnExecute();
        }

        protected abstract void OnExecute();

        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
    }
}
