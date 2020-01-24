using UnityEditor;
using UnityEngine;

public class FindObjectsWithTagDiagnostic : EditorWindow {
	
	#if UNITY_EDITOR
	string Tag;
	int Layer;
	string optionsInfo;
	bool[] options = new bool[2]{true,false};
	bool Started = false;
	bool Russian = false;
	private string startStr = "Start";
	GameObject[] objects;

	[MenuItem("Window/Tag&LayerDiagnostic")]
	public static void ShowWindow () 
	{
		GetWindow<FindObjectsWithTagDiagnostic> ("Tag&LayerDiagnostic");
	}

	void OnGUI ()
	{
		if (Russian == false) {
			GUILayout.Label ("Choose the Tag or a Layer to search and Click Start Diagnostic.", EditorStyles.boldLabel);
			Tag = (EditorGUILayout.TagField ("Choose your Tag:", Tag, GUILayout.MaxWidth (350)));
			Layer = (EditorGUILayout.LayerField ("Choose your Layer:", Layer, GUILayout.MaxWidth (350)));
			startStr = "Start";
		} else 
		{
			GUILayout.Label ("Выберите Тег или Слой для поиска и нажмите кнопку начать диагностику.", EditorStyles.boldLabel);
			Tag = (EditorGUILayout.TagField ("Выберите Тег:" ,Tag ,GUILayout.MaxWidth (350)));
			Layer = (EditorGUILayout.LayerField ("Выберите Слой:", Layer, GUILayout.MaxWidth (350)));
			startStr = "Начать";
		}
		if (Started == false) {
			Tag = "Untagged";
			Started = true;
		}
		if (GUILayout.Button ((startStr), (GUILayout.MaxWidth (100)))) {
			if (options [0] == true) {
				objects = GameObject.FindGameObjectsWithTag (Tag);
				Selection.objects = objects;
			}
			if (options [1] == true) {
				var goArray = FindObjectsOfType (typeof(GameObject)) as GameObject[];
				var goList = new System.Collections.Generic.List<GameObject> ();
				for (int i = 0; i < goArray.Length; i++) {
					if (goArray [i].layer == Layer) {
						goList.Add (goArray [i]);
						Selection.objects = goList.ToArray();
					}
				}
			}
		}
		Russian = GUILayout.Toggle (Russian, "Russian");
		if (Russian == false) {
			GUILayout.Label ("Options search.", EditorStyles.boldLabel);
			options [0] = EditorGUILayout.Toggle ("Search for a Tag :",options[0]);
			options [1] = EditorGUILayout.Toggle ("Search for a Layer :",options[1]);
			GUILayout.Label ("Created by oscar7070(Ver 1.3 Data 24/01/2020)for unity 2017.4))");
		} else 
		{
			GUILayout.Label ("Параметры поиска.", EditorStyles.boldLabel);
			options [0] = EditorGUILayout.Toggle ("Искать Тег :",options[0]);
			options [1] = EditorGUILayout.Toggle ("Искать Слой :",options[1]);
			GUILayout.Label ("Создано oscar7070(Версия 1.3 Дата 24/01/2020)дла unity 2017.4))");
		}
	}
	#endif
}