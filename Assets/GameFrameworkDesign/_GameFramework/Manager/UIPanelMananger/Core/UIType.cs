using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Manager { 

	/// <summary>
	/// 存储单个UI的信息，名字和路径
	/// </summary>
	public class UIType 
	{
		// UI 名字
		public string Name { get; private set; }
		// UI 路径
		public string Path { get; private set; }

		public UIType(string path) {
			Path = path;
			Name = path.Substring(path.LastIndexOf('/') + 1);
		}
	}
}
