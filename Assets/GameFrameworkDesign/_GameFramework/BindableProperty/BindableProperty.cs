using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign { 

	/// <summary>
	/// 服务 Model 自动添加相关属性事件
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BindableProperty<T> where T:IEquatable<T>
	{
		private T mValue = default(T);

		public T Value {
			get {
				return mValue;
			}
			set {
                if (value.Equals(mValue)==false)
                {
					mValue = value;
					OnValueChange?.Invoke(value);
                }
			}
		}

		public Action<T> OnValueChange;
	}
}
