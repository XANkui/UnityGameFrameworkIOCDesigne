using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class ShootCommand : AbstractCommand
	{
        public readonly static ShootCommand Single = new ShootCommand();
        public override void OnExecute()
        {
            this.GetSystem<IGunSystem>().CurrentGun.BulletCount.Value--;
        }
    }
}
