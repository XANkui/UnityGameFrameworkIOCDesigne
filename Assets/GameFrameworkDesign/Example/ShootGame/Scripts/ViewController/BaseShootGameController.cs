using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public abstract class BaseShootGameController : MonoBehaviour,IController
	{
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return ShootGame.Interface;
        }
    }
}
