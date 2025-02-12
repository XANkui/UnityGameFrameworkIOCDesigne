﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class ShootGame : Architecture<ShootGame>
	{
        protected override void Init()
        {
            this.RegisterSystem<ITimeSystem>(new TimeSystem());
            this.RegisterSystem<IStateSystem>(new StateSystem());
            this.RegisterSystem<IGunSystem>(new GunSystem());

            this.RegisterModel<IPlayerModel>(new PlayerModel());
            this.RegisterModel<IGunConfigModel>(new GunConfigModel());
        }
    }
}
