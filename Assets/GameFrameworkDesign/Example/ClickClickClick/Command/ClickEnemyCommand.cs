using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class ClickEnemyCommand : AbstractCommand
	{
        public override void OnExecute()
        {
            IGameModel gameModel = ClickClickClickArchitecture.Get<IGameModel>();
            gameModel.Count.Value++;

            if (gameModel.Count.Value >= 10)
            {
                this.SendEvent<OnGamePass>();
            }
        }
    }
}
