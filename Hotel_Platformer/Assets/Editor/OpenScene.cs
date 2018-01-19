using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OpenScene : MonoBehaviour {
    [MenuItem("OpenScene / StartScreen")]
    static void StartScreen() {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/StartScreen.unity");
    }
    [MenuItem("OpenScene / scene1")]
    static void Scene1()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        EditorApplication.OpenScene("Assets/Scenes/scene1.unity");
    }


}
