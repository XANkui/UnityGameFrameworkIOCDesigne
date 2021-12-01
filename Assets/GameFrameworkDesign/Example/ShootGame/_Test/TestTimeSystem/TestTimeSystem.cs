using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame.Test { 

	public class TestTimeSystem : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			Debug.Log("Time start : "+ Time.time);
			ShootGame.Interface.GetSystem<ITimeSystem>().AddDelayTask(3,()=> {
				Debug.Log("End start : " + Time.time);
			});
		}

		
	}
}
