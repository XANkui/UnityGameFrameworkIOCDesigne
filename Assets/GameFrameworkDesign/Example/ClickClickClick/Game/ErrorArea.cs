using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class ErrorArea : MonoBehaviour, IController
    {
        private void OnMouseDown()
        {
            this.SendCommand<MissCommand>();
        }

        public IArchitecture GetArchitecture()
        {
            return ClickClickClickArchitecture.Interface;
        }
    }
}
