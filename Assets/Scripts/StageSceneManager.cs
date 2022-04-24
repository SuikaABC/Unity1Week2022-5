using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSceneManager : MonoBehaviour
{
    public void OnToStageSelectButton()
    {
        SceneTransitionManager.I.Load(SceneEnum.StageSelect);
    }
}
