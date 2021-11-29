using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example {

    public interface ICountDownSystem : ISystem
    {

        int CurrentRemainSeconds { get; }

        void Update();
    }

    public class CountDownSystem : AbstractSystem, ICountDownSystem
    {
        protected override void OnInit()
        {
            this.RegisterEvent<OnGameStart>(e =>
            {
                mStarted = true;
                mGameStartTime = DateTime.Now;

            });

            this.RegisterEvent<OnGamePass>(e =>
            {
                mStarted = false;
            });
        }

        private DateTime mGameStartTime { get; set; }

        private bool mStarted = false;

        public int CurrentRemainSeconds => 10 - (int)(DateTime.Now - mGameStartTime).TotalSeconds;

        public void Update()
        {
            if (mStarted)
            {
                if (DateTime.Now - mGameStartTime > TimeSpan.FromSeconds(10))
                {
                    this.SendEvent<OnCountDownEndEvent>();
                    mStarted = false;
                }
            }
        }
    }
}
