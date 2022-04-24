using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneEnum
{
    TitleScene,
    GameScene
}

public static class SceneInfo
{
    private static Dictionary<SceneEnum, string> SceneNames = new Dictionary<SceneEnum, string>()
    {
        { SceneEnum.GameScene, "GameScene" },
        { SceneEnum.TitleScene, "TitleScene" }
    };

    public static string GetSceneName(SceneEnum sceneEnum)
    {
        return SceneNames[sceneEnum];
    }
}