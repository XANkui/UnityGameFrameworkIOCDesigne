using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class KillEnemyCommand : AbstractCommand
	{
        public override void OnExecute()
        {
            this.GetSystem<IStateSystem>().KillCount.Value++;

            var randomIndex = Random.Range(0,100);
            if (randomIndex<80)
            {
                this.GetSystem<IGunSystem>().CurrentGun.BulletCount.Value += Random.Range(0,4);
            }
        }
    }
}
