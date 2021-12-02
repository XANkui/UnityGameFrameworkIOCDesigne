using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class LevelPlayer : BaseShootGameController
	{
        enum PlayerState
        {
            SelectLevelFile,
            Playing
        }

        private PlayerState mCurrentLevelFile = PlayerState.SelectLevelFile;

        private string mLevelFilesFolder;
        private void Awake()
        {
            mLevelFilesFolder = Application.persistentDataPath + "/LevelFiles";
        }


        void ParseAndRun(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            var levelNode = document.SelectSingleNode("Level");

            foreach (XmlElement levelItemNode in levelNode.ChildNodes)
            {
                var levelItemName = levelItemNode.Attributes["name"].Value;
                var levelItemX = int.Parse(levelItemNode.Attributes["x"].Value);
                var levelItemY = int.Parse(levelItemNode.Attributes["y"].Value);

                var levelItemPrefab = Resources.Load<GameObject>(levelItemName);

                var levelItemGameObj = Instantiate(levelItemPrefab, transform);
                levelItemGameObj.transform.position = new Vector3(levelItemX, levelItemY, 0);
            }
        }

        private void OnGUI()
        {
            if (mCurrentLevelFile == PlayerState.SelectLevelFile)
            {
                int y = 10;

                foreach (var filePath in Directory.GetFiles(mLevelFilesFolder).Where(f => f.EndsWith("xml")))
                {
                    var fileName = Path.GetFileName(filePath);

                    if (GUI.Button(new Rect(10, y, 150, 40), fileName))
                    {
                        var xml = File.ReadAllText(filePath);
                        ParseAndRun(xml);
                        mCurrentLevelFile = PlayerState.Playing;
                    }

                    y += 50;
                }
            }

        }
    }
}
