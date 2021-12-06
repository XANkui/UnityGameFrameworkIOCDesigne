using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	/// <summary>
	/// ICanSendQuery 扩展类，支持继承 this 发送 SendQuery 命令
	/// </summary>
	public interface ICanSendQuery : IBelongToArchitecture
	{
		
	}

	public static class CanSendQueryExtension {
		public static T SendQuery<T>(this ICanSendQuery self,IQuery<T> query) {
			return self.GetArchitecture().SendQuery<T>(query);
		}
	}
}
