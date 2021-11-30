using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class HurtPlayerCommand : AbstractCommand
	{
        public int mHurtCOunt;

        public HurtPlayerCommand(int hurtCOunt)
        {
            this.mHurtCOunt = hurtCOunt;
        }

        public override void OnExecute()
        {
            this.GetModel<IPlayerModel>().HP.Value -= mHurtCOunt;
        }
    }
}
