using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	/// <summary>
	/// 继承该接口，可以有发送命令功能
	/// </summary>
	public interface ICanSendCommand : IBelongToArchitecture
	{
		
	}

	/// <summary>
	/// ICanSendCommand 扩展类
	/// 实现发送命令功能
	/// </summary>
	public static class CanSendCommandExtension {
		public static void SendCommand<T>(this ICanSendCommand self) where T : ICommand, new()
		{
			self.GetArchitecture().SendCommand<T>();
		}

		public static void SendCommand<T>(this ICanSendCommand self,T command) where T : ICommand
		{
			self.GetArchitecture().SendCommand<T>(command);
		}
		}
}
