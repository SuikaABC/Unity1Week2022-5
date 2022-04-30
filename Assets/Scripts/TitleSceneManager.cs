using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuikaDev.Scenes;
using Cysharp.Threading.Tasks;

public class TitleSceneManager : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneTransitionManager.I.FadeAndReplaceScene(Scenes.StageSelect).Forget();
    }
}
