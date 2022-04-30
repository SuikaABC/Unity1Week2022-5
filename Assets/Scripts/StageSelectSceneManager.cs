using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuikaDev.Scenes;
using Cysharp.Threading.Tasks;

public class StageSelectSceneManager : MonoBehaviour
{

    public void OnToTitleButton()
    {
        SceneTransitionManager.I.FadeAndReplaceScene(Scenes.TitleScene).Forget();
    }

    public void OnToStageButton(int number)
    {
        SceneTransitionManager.I.FadeAndReplaceScene(SceneGroups.Stage, number).Forget();
    }
}
