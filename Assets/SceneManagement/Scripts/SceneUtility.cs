using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuikaDev.Scenes
{
    public enum Scenes
    {
        TitleScene,
        StageSelect,
        ResultScene,
    }

    public enum SceneGroups
    {
        Stage
    }

    public enum LoadSceneMode
    {
        Single,
        Additive
    }

    public static class SceneUtility
    {
        public static string SceneEnumToSceneName(Scenes scene)
        {
            return scene.ToString();
        }
        public static Scenes SceneNameToSceneEnum(string sceneName)
        {
            if (System.Enum.TryParse(sceneName, out Scenes scene))
            {
                return scene;
            }

            if (sceneName.Contains("_"))
            {
                Debug.LogError($"SceneGroupに所属しているSceneなので、Enum型に変換できませんでした。");
            }
            Debug.LogError($"Enum型に変換できませんでした。");
            return default;
        }

        public static string SceneInGroupToSceneName(SceneGroups sceneGroup, int number)
        {
            return $"{sceneGroup}_{number}";
        }
        public static (SceneGroups Group, int Number) SceneNameToSceneInGroup(string sceneName)
        {
            if (!sceneName.Contains("_"))
            {
                Debug.LogError($"SceneGroupに所属していないSceneなので、Enum型に変換できませんでした。");
            }

            string[] splitedSceneName = sceneName.Split('_');
            if (splitedSceneName.Length != 2)
            {
                Debug.LogError($"SceneGroupに所属していないSceneなので、Enum型に変換できませんでした。");
            }
            string sceneGroupName = splitedSceneName[0];
            string numberString = splitedSceneName[1];

            if (System.Enum.TryParse(sceneGroupName, out SceneGroups sceneGroup))
            {
                if (int.TryParse(numberString, out int number))
                {
                    return (sceneGroup, number);
                }
            }
            Debug.LogError($"Enum型またはInt型に変換できませんでした。");
            return default;
        }
    }
}