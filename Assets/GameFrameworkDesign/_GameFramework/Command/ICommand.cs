
namespace GameFrameworkDesign {

    /// <summary>
    /// ICommand 不能有状态
    ///   ICanGetSystem, ICanGetModel, ICanGetUtility，ICanSendEvent,ICanSendCommand，使用规则，使得继承类可以获取 System，Model 和 Utility，SendEvent,SendCommand
    /// </summary>
    public interface ICommand :IBelongToArchitecture,ICanSetArchitecture, ICanGetSystem, ICanGetModel, ICanGetUtility, ICanSendEvent, ICanSendCommand
    {
		void Execute();
	}

	public abstract class AbstractCommand : ICommand {

        private IArchitecture mArchitecture;
        void ICommand.Execute()
        {
            OnExecute();
        }

        public abstract void OnExecute();

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
