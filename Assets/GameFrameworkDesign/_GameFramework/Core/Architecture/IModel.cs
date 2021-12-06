using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

    /// <summary>
    /// 模型层：IModel 接口，负责数据的定义以及数据的增删改查方法的的提供。
    /// IModel 状态发生变更后通知 IController 必须用事件 或 BindableProeprty。
    ///  ICanGetUtility, ICanSendEvent，使用规则，使得继承类可以获取 Utility 和 SendEvent
    /// </summary>
    public interface IModel : IBelongToArchitecture,ICanSetArchitecture, ICanGetUtility, ICanSendEvent
    {
		void Init();
	}
    public abstract class AbstractModel : IModel
    {

        private IArchitecture mArchitecture;
        void IModel.Init()
        {
            OnInit();
        }

        public abstract void OnInit();

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
