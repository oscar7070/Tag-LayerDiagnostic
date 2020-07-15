#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class FindObjectsWithTagDiagnostic : EditorWindow
{

	string Tag;
	int Layer;
	string optionsInfo;
	bool Started = false;
	bool Russian = false;
	private string startStr = "Start";
	GameObject[] objects;
	public string[] optionsLang = new string[] { "English", "Russian" };
	public int LangIndex = 0;
	public string[] optionsFindEn = new string[] { "Search for a Tag", "Search for a Layer" };
	public string[] optionsFindRu = new string[] { "Искать Тег", "Искать Слой" };
	public int FindIndex = 0;

	[MenuItem("Window/Tag&LayerDiagnostic")]
	public static void ShowWindow()
	{
		GetWindow<FindObjectsWithTagDiagnostic>("Tag&LayerDiagnostic");
	}

	void OnGUI()
	{
		if (LangIndex == 0)
		{
			GUILayout.Label("Choose the Tag or a Layer to search and Click Start Diagnostic.", EditorStyles.boldLabel);
			FindIndex = EditorGUILayout.Popup(FindIndex, optionsFindEn, GUILayout.MaxWidth(150));
			if (FindIndex == 0)
			{
				Tag = (EditorGUILayout.TagField("Choose your Tag:", Tag, GUILayout.MaxWidth(350)));
			}
			else
			{
				Layer = (EditorGUILayout.LayerField("Choose your Layer:", Layer, GUILayout.MaxWidth(350)));
			}
			startStr = "Start";
		}
		else if (LangIndex == 1)
		{
			GUILayout.Label("Выберите Тег или Слой для поиска и нажмите кнопку начать диагностику.", EditorStyles.boldLabel);
			FindIndex = EditorGUILayout.Popup(FindIndex, optionsFindRu, GUILayout.MaxWidth(150));
			if (FindIndex == 0)
			{
				Tag = (EditorGUILayout.TagField("Выберите Тег:", Tag, GUILayout.MaxWidth(350)));
			}
			else
			{
				Layer = (EditorGUILayout.LayerField("Выберите Слой:", Layer, GUILayout.MaxWidth(350)));
			}
			startStr = "Начать";
		}
		if (Started == false)
		{
			Tag = "Untagged";
			Started = true;
		}
		if (GUILayout.Button((startStr), (GUILayout.MaxWidth(100))))
		{
			if (FindIndex == 0)
			{
				objects = GameObject.FindGameObjectsWithTag(Tag);
				Selection.objects = objects;
			}
			if (FindIndex == 1)
			{
				var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
				var goList = new System.Collections.Generic.List<GameObject>();
				for (int i = 0; i < goArray.Length; i++)
				{
					if (goArray[i].layer == Layer)
					{
						goList.Add(goArray[i]);
						Selection.objects = goList.ToArray();
					}
				}
			}
		}
		LangIndex = EditorGUILayout.Popup(LangIndex, optionsLang, GUILayout.MaxWidth(100));
		if (LangIndex == 0)
		{
			GUILayout.Label("Created by oscar7070(Ver 1.4 Data 15/07/2020)");
		}
		else if (LangIndex == 1)
		{
			GUILayout.Label("Создатель oscar7070(Версия 1.4 Дата 15/07/2020)");
		}
	}
}
#endif