using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneTransitionManager.I.Load("GameScene");
    }
}
