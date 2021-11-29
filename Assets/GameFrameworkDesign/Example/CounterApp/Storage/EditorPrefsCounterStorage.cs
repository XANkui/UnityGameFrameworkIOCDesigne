#if UNITY_EDITOR
using UnityEditor;
#endif


namespace CounterApp { 

	public class EditorPrefsCounterStorage : ICounterStorage
	{
        public void SaveInt(string key, int value)
        {
#if UNITY_EDITOR
            EditorPrefs.SetInt(key, value);
#endif

        }

        public int LoadInt(string key, int defaultValue = 0)
        {
#if UNITY_EDITOR
            return EditorPrefs.GetInt(key, defaultValue);
#else
            return defaultValue;
#endif

        }
    }
}
