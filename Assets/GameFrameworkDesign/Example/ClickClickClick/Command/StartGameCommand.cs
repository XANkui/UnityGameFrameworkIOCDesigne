using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class StartGameCommand : AbstractCommand
	{
        public override void OnExecute()
        {
            this.SendEvent<OnGameStart>();
        }
    }
}
