
using UnityEngine;

namespace GameFrameworkDesign.Test { 

	public class TestLoadGameConfig : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			LoadGameConfig();
		}

		private void LoadGameConfig() {
			GameConfig[] results = Resources.FindObjectsOfTypeAll<GameConfig>();
			if (results.Length == 0)
			{
				Debug.LogError(" results length is 0 for type" + typeof(GameConfig).ToString() + ".");
				return;
			}

			if (results.Length > 1)
			{
				Debug.LogError(" results length is greater than 1 for type" + typeof(GameConfig).ToString() + ".");
				return;
			}
			//GameConfig gameConfig = Resources.Load<GameConfig>("GameConfig");
			GameConfig gameConfig = results[0];
			Debug.Log("GameConfig.IsRealse = " + gameConfig.IsRealse);
			Debug.Log("GameConfig.GameName = " + gameConfig.GameName);

			
		}
	}
}
