using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
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
            .Append(fadeImage.DOFade(1, 1f))
            .AppendCallback(() => SceneManager.LoadScene(sceneName))
            .Append(fadeImage.DOFade(0, 1f))
            .OnComplete(() =>
            {
                fadeImage.gameObject.SetActive(false);
            });
    }
}
