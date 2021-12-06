using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign { 

	/// <summary>
	/// 继承该接口，可以有获取数据模型 Model 功能
	/// </summary>
	public interface ICanGetModel:IBelongToArchitecture 
	{
		
	}

	/// <summary>
	/// ICanGetModel 扩展类
	/// 实现获取数据模型 Model 功能
	/// </summary>
	public static class CanGetModelExtension
	{
		public static T GetModel<T>(this ICanGetModel self) where T : class, IModel
		{
			return self.GetArchitecture().GetModel<T>();
		}
	}
}
