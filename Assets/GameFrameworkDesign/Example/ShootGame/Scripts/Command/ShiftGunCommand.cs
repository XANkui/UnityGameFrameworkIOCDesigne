using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class ShiftGunCommand : AbstractCommand
	{


        protected override void OnExecute()
        {
            this.GetSystem<IGunSystem>().ShiftGun();
        }
    }
}
