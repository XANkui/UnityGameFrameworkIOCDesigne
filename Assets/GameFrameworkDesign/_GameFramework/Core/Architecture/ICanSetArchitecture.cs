using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	// 继承该接口，可以设置框架，设置已自动在 Architecture 实现
	public interface ICanSetArchitecture 
	{
		void SetArchitecture(IArchitecture architecture);
	}
}
