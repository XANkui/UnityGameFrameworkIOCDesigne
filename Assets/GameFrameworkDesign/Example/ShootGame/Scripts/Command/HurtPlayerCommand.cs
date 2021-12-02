using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            var playerModel = this.GetModel<IPlayerModel>();

            playerModel.HP.Value -= mHurtCOunt;

            if (playerModel.HP.Value <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
