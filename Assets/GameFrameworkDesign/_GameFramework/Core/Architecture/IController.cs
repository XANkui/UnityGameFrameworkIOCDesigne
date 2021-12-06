using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	/// <summary>
	/// 表现层：IController 接口，负责接收输入和当状态变化时更新表现，一般情况下 MonoBehaviour 均为表现层对象。
	/// IController 更改 ISystem、IModel 的状态必须用 Command。
	/// IController 可以获取 ISystem、IModel 对象来进行数据查询
	///  ICanGetSystem, ICanGetModel, ICanSendCommand，ICanRegisterEvent，ICanSendQuery,使用规则，使得继承类可以获取 System,Model 和 SendCommand, RegisterEvent,ICanSendQuery
	/// </summary>
	public interface IController :IBelongToArchitecture, ICanGetSystem, ICanGetModel, ICanSendCommand, ICanRegisterEvent, ICanSendQuery
	{
		
	}
}
