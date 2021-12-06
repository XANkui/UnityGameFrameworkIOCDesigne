using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	/// <summary>
	/// ScriptableObject 单例
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SingletonScriptableObject<T> : ScriptableObject where T :ScriptableObject
	{
		private static T mInstance = null;

		public static T Instance {
			get {
                if (mInstance == null)
                {
					T[] results = Resources.FindObjectsOfTypeAll<T>();
                    if (results.Length==0)
                    {
						Debug.LogError("SingletonScriptableObject -> Instance -> results length is 0 for type"+typeof(T).ToString()+".");
						return null;
					}

                    if (results.Length>1)
                    {
						Debug.LogError("SingletonScriptableObject -> Instance -> results length is greater than 1 for type" + typeof(T).ToString() + ".");
						return null;
					}

					mInstance = results[0];
                }

				return mInstance;
			}
		}
	}
}
