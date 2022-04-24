using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneEnum
{
    TitleScene,
    StageSelect
}

public enum SceneGroupEnum
{
    Stages
}

public static class SceneCollectionInfo
{
    private static Dictionary<SceneEnum, string> SceneNames = new Dictionary<SceneEnum, string>()
    {
        { SceneEnum.StageSelect, "StageSelect" },
        { SceneEnum.TitleScene, "TitleScene" }
    };

    private static Dictionary<SceneGroupEnum, string> StageNames = new Dictionary<SceneGroupEnum, string>()
    {
        { SceneGroupEnum.Stages, "Stage" },
    };

    public static string GetSceneName(SceneEnum sceneEnum)
    {
        return SceneNames[sceneEnum];
    }
    public static string GetSceneNameFromGroup(SceneGroupEnum stageSceneEnum, int number)
    {
        return StageNames[stageSceneEnum] + number.ToString();
    }
}