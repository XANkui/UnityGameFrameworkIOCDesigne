using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign { 

	/// <summary>
	/// IOC 管理所有注册的 System，Model，和 Utility
	/// </summary>
	public class IOCContainer 
	{
		private Dictionary<Type, object> mInstances = new Dictionary<Type, object>();

		public void Register<T>(T instance) {
			var key = typeof(T);
			if (mInstances.ContainsKey(key))
			{
				mInstances[key] = instance;
			}
			else {
				mInstances.Add(key,instance);
			}
		}

		public T Get<T>() where T : class {
			var key = typeof(T);

			object retInstance;
            if (mInstances.TryGetValue(key,out retInstance))
            {
				return retInstance as T;
            }

			Debug.LogError("There is no instance，T = "+ key);
			return null;
		}
	}
}
