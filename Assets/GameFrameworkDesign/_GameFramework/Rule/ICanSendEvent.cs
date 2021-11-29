

namespace GameFrameworkDesign {

    /// <summary>
	/// 继承该接口，可以有发送事件功能
	/// </summary>
    public interface ICanSendEvent : IBelongToArchitecture
    {

    }

    /// <summary>
	/// ICanSendEvent 扩展类
	/// 实现发送事件功能
	/// </summary>
    public static class CanSendEventExtension
    {
        public static void SendEvent<T>(this ICanSendEvent self) where T : new()
        {
            self.GetArchitecture().SendEvent<T>();
        }

        public static void SendEvent<T>(this ICanSendEvent self, T e)
        {
            self.GetArchitecture().SendEvent<T>(e);
        }
    }
}
