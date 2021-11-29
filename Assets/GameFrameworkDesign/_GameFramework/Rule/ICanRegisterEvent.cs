

using System;

namespace GameFrameworkDesign {

    /// <summary>
    /// 继承该接口，可以有注册事件功能
    /// </summary>
    public interface ICanRegisterEvent : IBelongToArchitecture
    {

    }

    /// <summary>
	/// ICanRegisterEvent 扩展类
	/// 实现注册事件功能
	/// </summary>
    public static class CanRegisterEventExtension
    {

        public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
            return self.GetArchitecture().RegisterEvent<T>(onEvent);
        }

        public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
            self.GetArchitecture().UnRegisterEvent<T>(onEvent);
        }
    }
}
