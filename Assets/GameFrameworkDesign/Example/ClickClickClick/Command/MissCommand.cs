using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class MissCommand : AbstractCommand
	{

        public override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            if (gameModel.Life.Value > 0)
            {
                gameModel.Life.Value--;
            }
            else
            {
                this.SendEvent<OnMissEvent>();
            }
        }
    }
}
