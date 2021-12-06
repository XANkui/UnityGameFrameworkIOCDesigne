using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

    /// <summary>
    /// 系统层：ISystem 接口，帮助 IController 承担一部分逻辑，在多个表现层共享的逻辑，比如计时系统、商城系统、成就系统等。
    /// ISystem 状态发生变更后通知 IController 必须用事件 或 BindableProeprty。
    ///  ICanGetModel, ICanGetUtility，ICanRegisterEvent, ICanSendEvent,ICanGetSystem，使用规则，
    ///  使得继承类可以获取 Model 和 Utility,并且注册和发送Event，同时也可以获取其他 System
    /// </summary>
    public interface ISystem :IBelongToArchitecture,ICanSetArchitecture, 
        ICanGetModel, ICanGetUtility, ICanRegisterEvent, ICanSendEvent, ICanGetSystem
    {
		void Init();
	}

	public abstract class AbstractSystem : ISystem {

        private IArchitecture mArchitecture;
        void ISystem.Init()
        {
            OnInit();
        }

        protected abstract void OnInit();

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
    }
}
