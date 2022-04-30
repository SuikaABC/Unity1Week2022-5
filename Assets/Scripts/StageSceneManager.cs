using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SuikaDev.Scenes;
using Cysharp.Threading.Tasks;

public class StageSceneManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(SceneUtility.SceneNameToSceneInGroup(SceneLoadManager.GetActiveSceneName()));
    }

    public void OnToStageSelectButton()
    {
        SceneTransitionManager.I.FadeAndReplaceScene(Scenes.StageSelect).Forget();
    }

    public void OnClearButton()
    {
        int stageNumber = SceneUtility.SceneNameToSceneInGroup(SceneLoadManager.GetActiveSceneName()).Number;
        SceneLoadManager.Add(Scenes.ResultScene, new StageToClearData() { StageNumber = stageNumber }).Forget();
    }
}
