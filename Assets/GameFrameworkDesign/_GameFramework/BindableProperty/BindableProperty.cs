using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign { 

	/// <summary>
	/// 服务 Model 自动添加相关属性事件
	/// </summary>
	/// <typeparam name="T"></typeparam>
	// public class BindableProperty<T> where T:IEquatable<T>
	public class BindableProperty<T> // 为了可使用 enum
	{
        private T mValue;

        public T Value
        {
            get => mValue;
            set
            {
                //if (!mValue.Equals(value))
                //{
                //    mValue = value;
                //    mOnValueChanged?.Invoke(value);
                //}

                
                // 为了可使用 enum
                mValue = value;
                mOnValueChanged?.Invoke(value);
                
            }
        }

        private Action<T> mOnValueChanged = (v) => { }; 

        public IUnRegister RegisterOnValueChanged(Action<T> onValueChanged) 
        {
            mOnValueChanged += onValueChanged;
            return new BindablePropertyUnRegister<T>()
            {
                BindableProperty = this,
                OnValueChanged = onValueChanged
            };
        }

        public void UnRegisterOnValueChanged(Action<T> onValueChanged) 
        {
            mOnValueChanged -= onValueChanged;
        }
    }

    //public class BindablePropertyUnRegister<T> : IUnRegister where T : IEquatable<T> 
    public class BindablePropertyUnRegister<T> : IUnRegister // 为了可使用 enum
    {
        public BindableProperty<T> BindableProperty { get; set; }

        public Action<T> OnValueChanged { get; set; }

        public void UnRegister()
        {
            BindableProperty.UnRegisterOnValueChanged(OnValueChanged);
        }
    }
}
