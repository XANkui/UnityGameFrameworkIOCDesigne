using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign { 

	public interface IQuery<T> : IBelongToArchitecture,ICanSetArchitecture,ICanGetModel,ICanGetSystem,ICanGetUtility
	{
		T Do();
	}

	public abstract class AbstractQuery<T> : IQuery<T>
	{
        public T Do()
        {
            return OnDo();
        }

        protected abstract T OnDo();

        private IArchitecture mArchitecture;

        public void SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }

        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }
    }
}
