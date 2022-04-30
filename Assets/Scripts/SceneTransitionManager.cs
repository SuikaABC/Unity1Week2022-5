using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using SuikaDev.Scenes;
using Cysharp.Threading.Tasks;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{

    protected override bool DestroyTargetGameObject => true;

    [SerializeField] private Image fadeImage;

    protected override void Init()
    {
        DontDestroyOnLoad(gameObject);
    }

    public async UniTask FadeAndReplaceScene(string sceneName, object sceneData = null)
    {
        await FadeOut();
        await SceneLoadManager.Replace(sceneName, sceneData);
        await FadeIn();
    }

    public async UniTask FadeAndReplaceScene(Scenes scene, object sceneData = null)
    {
        await FadeOut();
        await SceneLoadManager.Replace(scene, sceneData);
        await FadeIn();
    }

    public async UniTask FadeAndReplaceScene(SceneGroups stageGroup, int number, object sceneData = null)
    {
        await FadeOut();
        await SceneLoadManager.Replace(stageGroup, number, sceneData);
        await FadeIn();
    }


    public async UniTask FadeAndAddScene(string sceneName, object sceneData = null)
    {
        await FadeOut();
        await SceneLoadManager.Add(sceneName, sceneData);
        await FadeIn();
    }

    public async UniTask FadeAndAddScene(Scenes scene, object sceneData = null)
    {
        await FadeOut();
        await SceneLoadManager.Add(scene, sceneData);
        await FadeIn();
    }

    public async UniTask FadeAndAddScene(SceneGroups stageGroup, int number, object sceneData = null)
    {
        await FadeOut();
        await SceneLoadManager.Add(stageGroup, number, sceneData);
        await FadeIn();
    }

    public async UniTask ReLoad()
    {
        await SceneLoadManager.ReLoad();
    }

    public async UniTask FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
        await fadeImage.DOFade(1, .2f);
    }
    public async UniTask FadeIn()
    {
        await fadeImage.DOFade(0, .2f);
        fadeImage.gameObject.SetActive(false);
    }
}
