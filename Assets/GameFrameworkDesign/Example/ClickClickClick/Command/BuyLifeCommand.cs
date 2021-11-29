using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example {

    public class BuyLifeCommand : AbstractCommand
    {
        public override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.Gold.Value--;
            gameModel.Life.Value++;
        }

    }
}
