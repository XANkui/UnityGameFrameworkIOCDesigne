using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	/// <summary>
	/// 继承该接口，可以有获取工具 Utility 功能
	/// </summary>
	public interface ICanGetUtility : IBelongToArchitecture
	{

	}

	/// <summary>
	/// ICanGetUtility 扩展类
	/// 实现获取工具 Utility 功能
	/// </summary>
	public static class CanGetUtilityExtension{
		public static T GetUtility<T>(this ICanGetUtility self)where T :class,IUtility {
			return self.GetArchitecture().GetUtility<T>();
		}
	}
}
