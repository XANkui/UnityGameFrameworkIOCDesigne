using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class TypeEventSystemExample : MonoBehaviour
	{
        /// <summary>
        /// 事件 A
        /// </summary>
        public struct EventA
        {

        }

        /// <summary>
        /// 事件 B
        /// </summary>
        public struct EventB
        {
            public int ParamB;
        }

        /// <summary>
        /// 支持事件的继承
        /// </summary>
        public interface IEventGroup
        {

        }

        public struct EventC : IEventGroup
        {

        }

        public struct EventD : IEventGroup
        {

        }

        private ITypeEventSystem mTypeEventSystem = null;

        void Start()
        {
            mTypeEventSystem = new TypeEventSystem();

            mTypeEventSystem.Register<EventA>(eA =>
            {
                Debug.Log("OnEventA");
            }).UnRegisterWhenGameObjectDestroyed(gameObject); // 当 GameObject 销毁时自动触发注销

            mTypeEventSystem.Register<EventB>(OnEventB);

            mTypeEventSystem.Register<IEventGroup>(group =>
            {
                Debug.Log(group.GetType());

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnEventB(EventB e)
        {
            Debug.Log("OnEventB:" + e.ParamB);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mTypeEventSystem.Send<EventA>();
            }

            if (Input.GetMouseButtonDown(1))
            {
                mTypeEventSystem.Send(new EventB()
                {
                    ParamB = 123
                });
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }

        private void OnDestroy()
        {
            mTypeEventSystem.UnRegister<EventB>(OnEventB);
            mTypeEventSystem = null;
        }
    }
}
