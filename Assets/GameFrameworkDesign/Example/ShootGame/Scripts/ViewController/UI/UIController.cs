using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class UIController : BaseShootGameController
	{
		private IPlayerModel mPlayerModel;
		private IStateSystem mStateSystem;
		private IGunSystem mGunSystem;
		private GunInfo mGunInfo;

		private Text mHPText;
		private Text mKillCountText;
		private Text mBulletCountInGunText;
		private Text mBulletCountOutGunText;
		private Text mGunNameText;
		private Text mGunStateText;
		private int TOTAL_HP;
		private int MAX_BULLET_COUNT;

		private void Awake()
        {
			mPlayerModel = this.GetModel<IPlayerModel>();
			mStateSystem = this.GetSystem<IStateSystem>();
			mGunSystem = this.GetSystem<IGunSystem>();
			mGunInfo = mGunSystem.CurrentGun;
			mHPText = transform.Find("Canvas/HPText").GetComponent<Text>();
			mKillCountText = transform.Find("Canvas/KillCountText").GetComponent<Text>();
			mBulletCountInGunText = transform.Find("Canvas/BulletCountInGunText").GetComponent<Text>();
			mBulletCountOutGunText = transform.Find("Canvas/BulletCountOutGunText").GetComponent<Text>();
			mGunNameText = transform.Find("Canvas/GunNameText").GetComponent<Text>();
			mGunStateText = transform.Find("Canvas/GunStateText").GetComponent<Text>();

			

		}

        // Start is called before the first frame update
        void Start()
		{
			TOTAL_HP = mPlayerModel.HP.Value;
			MAX_BULLET_COUNT = this.SendQuery(new MaxBulletCountQuery(mGunInfo.GunName.Value));
			this.RegisterEvent<OnCurrentGunChangedEvent>((e) => {
				MAX_BULLET_COUNT = this.SendQuery(new MaxBulletCountQuery(e.GunName));
				UpdateBulletCountInGunText(mGunInfo.BulletCountInGun.Value);
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			mPlayerModel.HP.RegisterOnValueChanged(UpdateHPText);
			mStateSystem.KillCount.RegisterOnValueChanged(UpdateKillCountText);
			mGunInfo.BulletCountInGun.RegisterOnValueChanged(UpdateBulletCountInGunText);
			mGunInfo.BulletCountOutGun.RegisterOnValueChanged(UpdateBulletCountOutGunText);
			mGunInfo.GunState.RegisterOnValueChanged(UpdateGunStateText);
			mGunInfo.GunName.RegisterOnValueChanged(UpdateGunNameText);

			UpdateHPText(mPlayerModel.HP.Value);
			UpdateKillCountText(mStateSystem.KillCount.Value);
			UpdateBulletCountInGunText(mGunInfo.BulletCountInGun.Value);
			UpdateBulletCountOutGunText(mGunInfo.BulletCountOutGun.Value);
			UpdateGunNameText(mGunInfo.GunName.Value);
			UpdateGunStateText(mGunInfo.GunState.Value);
		}

		void UpdateHPText(int hp) {
			mHPText.text = "生命："+ hp+"/"+ TOTAL_HP;
		}
		void UpdateKillCountText(int killCount)
		{
			mKillCountText.text = "击杀：" + killCount;
		}
		void UpdateBulletCountInGunText(int BulletCount)
		{
			mBulletCountInGunText.text = "枪内子弹：" + BulletCount+"/"+ MAX_BULLET_COUNT;
		}

		void UpdateBulletCountOutGunText(int BulletCount)
		{
			mBulletCountOutGunText.text = "枪外子弹：" + BulletCount;
		}

		void UpdateGunStateText(GunState gunState)
		{
			mGunStateText.text = "枪状态：" + gunState;
		}

		void UpdateGunNameText(string name)
		{
			mGunNameText.text = "枪名：" + name;
		}

		private void OnDestroy()
        {
			mPlayerModel.HP.UnRegisterOnValueChanged(UpdateHPText);
			mStateSystem.KillCount.UnRegisterOnValueChanged(UpdateKillCountText);
		}

        
    }
}
