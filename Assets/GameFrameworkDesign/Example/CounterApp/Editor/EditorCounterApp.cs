using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CounterApp.Editor { 

	public class EditorCounterApp : EditorWindow
	{
		[MenuItem("EditorCounterApp/Open")]
		static void Open() {
			
			CounterAppArchitecture.OnRegisterPatch += architecture =>
			{
				architecture.RegisterUtility<ICounterStorage>(new EditorPrefsCounterStorage());
			};
			var window = GetWindow<EditorCounterApp>();
			window.position = new Rect(100,100,400,600);
			window.titleContent = new GUIContent(nameof(EditorCounterApp));
			window.Show();
		}

        private void OnGUI()
        {
			if (GUILayout.Button("+"))
            {
				new AddCommand().OnExecute();
            }

			GUILayout.Label(CounterAppArchitecture.Get<ICounterStorage>().LoadInt("COUNTER_COUNT").ToString());

			if (GUILayout.Button("-"))
			{
				new SubCommand().OnExecute();
			}
		}
    }
}
