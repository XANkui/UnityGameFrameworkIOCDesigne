using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	/// <summary>
	/// 继承该接口，可以有获取系统 System 功能
	/// </summary>
	public interface ICanGetSystem : IBelongToArchitecture
	{
		
	}

	/// <summary>
	/// ICanGetSystem 扩展类
	/// 实现获取系统 System 功能
	/// </summary>
	public static class CanGetSystemExtension
	{
		public static T GetSystem<T>(this ICanGetSystem self) where T : class, ISystem
		{
			return self.GetArchitecture().GetSystem<T>();
		}
	}
}
