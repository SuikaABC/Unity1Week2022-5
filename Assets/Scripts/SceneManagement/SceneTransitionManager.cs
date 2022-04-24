using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 使い方
// 1 オブジェクトにアタッチ
// 2 オブジェクトの子にキャンバス、その子にImageを配置
// 3 このスクリプトのfadeImageにそのImageを参照させる


public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    protected override bool DestroyTargetGameObject => true;

    [SerializeField] private Image fadeImage;

    protected override void Init()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Load(string sceneName)
    {
        DOTween.Sequence()
            .OnStart(() =>
            {
                fadeImage.gameObject.SetActive(true);
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
            })
            .Append(fadeImage.DOFade(1, .2f))
            .AppendCallback(() => SceneManager.LoadScene(sceneName))
            .Append(fadeImage.DOFade(0, .2f))
            .OnComplete(() =>
            {
                fadeImage.gameObject.SetActive(false);
            });
    }


    public void Load(SceneEnum sceneEnum)
    {
        DOTween.Sequence()
            .OnStart(() =>
            {
                fadeImage.gameObject.SetActive(true);
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
            })
            .AppendInterval(0.05f)
            .Append(fadeImage.DOFade(1, .2f))
            .AppendCallback(() => SceneManager.LoadScene(SceneInfo.GetSceneName(sceneEnum)))
            .AppendInterval(0.2f)
            .Append(fadeImage.DOFade(0, .2f))
            .OnComplete(() =>
            {
                fadeImage.gameObject.SetActive(false);
            });
    }

    public void Load(SceneGroupEnum stageEnum, int number)
    {
        DOTween.Sequence()
            .OnStart(() =>
            {
                fadeImage.gameObject.SetActive(true);
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
            })
            .AppendInterval(0.05f)
            .Append(fadeImage.DOFade(1, .2f))
            .AppendCallback(() => SceneManager.LoadScene(SceneInfo.GetSceneNameFromGroup(stageEnum, number)))
            .AppendInterval(0.2f)
            .Append(fadeImage.DOFade(0, .2f))
            .OnComplete(() =>
            {
                fadeImage.gameObject.SetActive(false);
            });
    }
}
