using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class LevelPlayer : MonoBehaviour
	{
		public TextAsset LevelFile;
		// Start is called before the first frame update
		void Start()
		{
			var xml = LevelFile.text;
			var document = new XmlDocument();
			document.LoadXml(xml);

			var levelNode = document.SelectSingleNode("Level");
            foreach (XmlElement levelItemNode in levelNode.ChildNodes)
            {
				var levelItemName = levelItemNode.Attributes["name"].Value;
				var levelItemX = int.Parse( levelItemNode.Attributes["x"].Value);
				var levelItemY = int.Parse(levelItemNode.Attributes["y"].Value);

				var levelItemPrefab = Resources.Load<GameObject>(levelItemName);
				var levelItemGameObj = Instantiate(levelItemPrefab,transform);
				levelItemGameObj.transform.position = new Vector3(levelItemX,levelItemY,0);
			}
		}

		
	}
}
