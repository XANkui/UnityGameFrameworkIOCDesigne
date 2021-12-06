using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign {

	/// <summary>
	/// 在 Resources 下创建，
	/// 使用 Resources 可以读取配置
	/// 下面属性参数只做功能演示
	/// </summary>
	[CreateAssetMenu(menuName ="XanConfig/GameConfig",fileName = "GameConfig")]
	public class GameConfig : ScriptableObject
	{
		[SerializeField]
		private bool _isRealse;
		public bool IsRealse { get => _isRealse; }

		[SerializeField]
		private string _gameBaseName;
		public string GameName {
			get
			{
				int value = Random.Range(0, 9999);
				return _gameBaseName + value.ToString();
			}
		}
	}
}
