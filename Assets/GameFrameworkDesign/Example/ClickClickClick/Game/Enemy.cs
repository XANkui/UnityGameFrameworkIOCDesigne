using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example
{ 
	public class Enemy : MonoBehaviour,IController
	{
        private void OnMouseDown()
        {

            
            GetArchitecture().SendCommand<ClickEnemyCommand>();
            gameObject.SetActive(false);
        }

        public IArchitecture GetArchitecture()
        {
            return ClickClickClickArchitecture.Interface;
        }
    }
}
