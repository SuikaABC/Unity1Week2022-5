using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuikaDev.Scenes;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class ClearCanvasManager : MonoBehaviour
{

    int stageNumber;

    public void Start()
    {
        if (SceneLoadManager.PrevSceneData is StageToClearData stageData)
        {
            stageNumber = stageData.StageNumber;
            Debug.Log(stageNumber);
        }
    }

    public void OnToStageSelectButton()
    {
        SceneTransitionManager.I.FadeAndReplaceScene(Scenes.StageSelect).Forget();
    }

    public void OnToNextStageButton()
    {
        SceneTransitionManager.I.FadeAndReplaceScene(SceneGroups.Stage, this.stageNumber + 1).Forget();
    }

    public void OnRetryButton()
    {
        SceneTransitionManager.I.ReLoad().Forget();
    }
}
