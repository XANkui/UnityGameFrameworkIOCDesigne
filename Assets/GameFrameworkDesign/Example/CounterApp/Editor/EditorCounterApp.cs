using GameFrameworkDesign;

using UnityEditor;
using UnityEngine;

namespace CounterApp.Editor { 

	public class EditorCounterApp : EditorWindow,IController
	{
        /// <summary>
        /// 打开窗口
        /// </summary>
        [MenuItem("EditorCounterApp/Open")]
        static void Open()
        {
            // 需要在这里切换一下 Storage 的实现
            CounterAppArchitecture.OnRegisterPatch += architecture =>
            {
                architecture.RegisterUtility<ICounterStorage>(new EditorPrefsCounterStorage());
            };

            var editorCounterApp = GetWindow<EditorCounterApp>();
            editorCounterApp.name = nameof(EditorCounterApp);
            editorCounterApp.position = new Rect(100, 100, 400, 600);
            editorCounterApp.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                this.SendCommand<AddCommand>();
            }

            //  由于实时刷新 所以直接就就渲染数据即可
            GUILayout.Label(this.GetModel<ICounterModel>().Count.Value.ToString());

            if (GUILayout.Button("-"))
            {
                this.SendCommand<SubCommand>();
            }
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return CounterAppArchitecture.Interface;
        }
    }
}
