using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp { 

	public class PlayerPrefsCounterStorage : ICounterStorage
	{
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key,value);
        }

        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }
}
