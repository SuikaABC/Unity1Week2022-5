using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public void OnToTitleButton()
    {
        SceneTransitionManager.I.Load(SceneEnum.TitleScene);
    }

    public void OnToStageButton(int number)
    {
        SceneTransitionManager.I.Load(SceneGroupEnum.Stages, number);
    }
}
