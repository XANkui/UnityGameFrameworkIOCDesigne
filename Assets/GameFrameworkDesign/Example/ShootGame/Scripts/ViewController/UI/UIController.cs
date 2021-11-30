using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class UIController : MonoBehaviour,IController
	{
		private IPlayerModel mPlayerModel;
		private IStateSystem mStateSystem;
		private IGunSystem mGunSystem;
		private GunInfo mGunInfo;

		private Text mHPText;
		private Text mKillCountText;
		private Text mBulletCountText;
		private int TOTAL_HP;

		private void Awake()
        {
			mPlayerModel = this.GetModel<IPlayerModel>();
			mStateSystem = this.GetSystem<IStateSystem>();
			mGunSystem = this.GetSystem<IGunSystem>();
			mGunInfo = mGunSystem.CurrentGun;
			mHPText = transform.Find("Canvas/HPText").GetComponent<Text>();
			mKillCountText = transform.Find("Canvas/KillCountText").GetComponent<Text>();
			mBulletCountText = transform.Find("Canvas/BulletCountText").GetComponent<Text>();
			
		}

        // Start is called before the first frame update
        void Start()
		{
			TOTAL_HP = mPlayerModel.HP.Value;
			mPlayerModel.HP.RegisterOnValueChanged(UpdateHPText);
			mStateSystem.KillCount.RegisterOnValueChanged(UpdateKillCountText);
			mGunInfo.BulletCount.RegisterOnValueChanged(UpdateBulletCountText);

			UpdateHPText(mPlayerModel.HP.Value);
			UpdateKillCountText(mStateSystem.KillCount.Value);
			UpdateBulletCountText(mGunInfo.BulletCount.Value);
		}

		void UpdateHPText(int hp) {
			mHPText.text = "生命："+ hp+"/"+ TOTAL_HP;
		}
		void UpdateKillCountText(int killCount)
		{
			mKillCountText.text = "击杀：" + killCount;
		}
		void UpdateBulletCountText(int BulletCount)
		{
			mBulletCountText.text = "子弹：" + BulletCount;
		}

		private void OnDestroy()
        {
			mPlayerModel.HP.UnRegisterOnValueChanged(UpdateHPText);
			mStateSystem.KillCount.UnRegisterOnValueChanged(UpdateKillCountText);
		}

        public IArchitecture GetArchitecture()
        {
			return ShootGame.Interface;
        }
    }
}
