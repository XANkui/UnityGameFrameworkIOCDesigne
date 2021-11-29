using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	public interface IArchitecture
	{
		/// <summary>
		/// 注册系统 System
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="system"></param>
		void RegisterSystem<T>(T system) where T : ISystem;
		/// <summary>
		/// 注册数据模型 Model
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		void RegisterModel<T>(T model) where T : IModel;
		/// <summary>
		/// 注册工具类 Utility
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="utility"></param>
		void RegisterUtility<T>(T utility) where T : IUtility;
		/// <summary>
		/// 获取系统 System
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		T GetSystem<T>() where T : class,ISystem;
		/// <summary>
		/// 获取数据模型 Model
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		T GetModel<T>() where T : class,IModel;	
		/// <summary>
		/// 获取工具 Utility
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		T GetUtility<T>() where T :class, IUtility;
		/// <summary>
		/// 发送命令 Command
		/// </summary>
		/// <typeparam name="T"></typeparam>
		void SendCommand<T>() where T : ICommand, new();
		/// <summary>
		/// 发送命令 Command
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="command"></param>
		void SendCommand<T>(T command) where T : ICommand;

		/// <summary>
		/// 发送事件
		/// </summary>
		void SendEvent<T>() where T : new();

		/// <summary>
		/// 发送事件
		/// </summary>
		void SendEvent<T>(T e); 

		/// <summary>
		/// 注册事件
		/// </summary>
		IUnRegister RegisterEvent<T>(Action<T> onEvent); 

		/// <summary>
		/// 注销事件
		/// </summary>
		void UnRegisterEvent<T>(Action<T> onEvent); 
	}
	public abstract class Architecture<T> : IArchitecture where T: Architecture<T>,new()
	{
		

		private static T mArchitecture;
		// 对外静态获取
		public static IArchitecture Interface
		{
			get
			{
				if (mArchitecture == null)
				{
					MakeSureArchitecture();
				}

				return mArchitecture;
			}
		}

		// 是否初始化过
		private bool mInited = false;
		private List<IModel> mModels = new List<IModel>();  // 缓存列表 为初始化使用
		private List<ISystem> mSystems = new List<ISystem>();   // 缓存列表 为初始化使用

		/// <summary>
		/// 注册补丁
		/// </summary>
		public static Action<T> OnRegisterPatch = architecture => { };

		/// <summary>
		/// 创建架构
		/// 包括一些已初始化
		/// </summary>
		static void MakeSureArchitecture() {
            if (mArchitecture==null)
            {
				mArchitecture = new T();
				mArchitecture.Init();

				OnRegisterPatch?.Invoke(mArchitecture);


				foreach (var architectureModel in mArchitecture.mModels)
                {
					architectureModel.Init();

				}
				
				// System 可能用到 model 的数据,所以 Model 先初始化
				foreach (var architectureSystem in mArchitecture.mSystems)
				{
					architectureSystem.Init();

				}

				mArchitecture.mModels.Clear();
				mArchitecture.mSystems.Clear();
				mArchitecture.mInited = true;
			}
		}


		/// <summary>
		/// 继承这需要实现初始化函数
		/// 主要 注册系统 System，数据模型 Model ，工具 Utiltity 等到框架中
		/// </summary>
		protected abstract void Init();

		// IOC 功能
		private IOCContainer mContainer = new IOCContainer();

		public void RegisterSystem<T1>(T1 system) where T1 : ISystem
		{
			system.SetArchitecture(this);
			mContainer.Register<T1>(system);
			if (mInited == false)
			{
				mSystems.Add(system);

			}
			else
			{
				system.Init();
			}
		}

		public void RegisterModel<T1>(T1 model) where T1 : IModel
		{
			model.SetArchitecture(this);
			mContainer.Register<T1>(model);
			if (mInited == false)
			{
				mModels.Add(model);

			}
			else
			{
				model.Init();
			}

		}

		public void RegisterUtility<T1>(T1 utility)where T1: IUtility
		{
			mContainer.Register<T1>(utility);
		}

		public T1 GetSystem<T1>() where T1 : class,ISystem
		{
			return mContainer.Get<T1>();
		}
		public T1 GetModel<T1>() where T1 : class,IModel
		{
			return mContainer.Get<T1>();
		}

		public T1 GetUtility<T1>() where T1 : class, IUtility
		{
			return mContainer.Get<T1>();

		}

        public void SendCommand<T1>() where T1 : ICommand, new()
        {
			T1 command = new T1();
			command.SetArchitecture(this);
			command.Execute();
        }

        public void SendCommand<T1>(T1 command) where T1 : ICommand
        {
			command.SetArchitecture(this);
			command.Execute();
		}

		private ITypeEventSystem mTypeEventSystem = new TypeEventSystem(); 

		public void SendEvent<T1>() where T1 : new() 
		{
			mTypeEventSystem.Send<T1>();
		}

		public void SendEvent<T1>(T1 e) 
		{
			mTypeEventSystem.Send<T1>(e);
		}

		public IUnRegister RegisterEvent<T1>(Action<T1> onEvent) 
		{
			return mTypeEventSystem.Register<T1>(onEvent);
		}

		public void UnRegisterEvent<T1>(Action<T1> onEvent)
		{
			mTypeEventSystem.UnRegister<T1>(onEvent);
		}

		
	}
}
