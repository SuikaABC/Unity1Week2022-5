using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 使い方
// 1 オブジェクトにアタッチ
// 2 オブジェクトの子にキャンバス、その子にImageを配置
// 3 このスクリプトのfadeImageにそのImageを参照させる

namespace SuikaDev.Scenes
{
    public static class SceneLoadManager
    {

        public static object PrevSceneData;

        public static string GetActiveSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        public static async UniTask Replace(string sceneName, object sceneData = null)
        {
            if (sceneData != null)
            {
                PrevSceneData = sceneData;
            }
            else
            {
                PrevSceneData = new object();
            }

            await SceneManager.LoadSceneAsync(sceneName);
        }

        public static async UniTask Replace(Scenes scene, object sceneData = null)
        {
            await Replace(SceneUtility.SceneEnumToSceneName(scene), sceneData);
        }

        public static async UniTask Replace(SceneGroups stageGroup, int number, object sceneData = null)
        {
            await Replace(SceneUtility.SceneInGroupToSceneName(stageGroup, number), sceneData);
        }


        public static async UniTask ReLoad()
        {
            await Replace(SceneManager.GetActiveScene().name);
        }


        public static async UniTask Add(string sceneName, object sceneData = null)
        {
            if (sceneData != null)
            {
                PrevSceneData = sceneData;
            }
            else
            {
                PrevSceneData = new object();
            }

            await SceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }


        public static async UniTask Add(Scenes scene, object sceneData = null)
        {
            await Add(SceneUtility.SceneEnumToSceneName(scene), sceneData);
        }

        public static async UniTask Add(SceneGroups stageGroup, int number, object sceneData = null)
        {
            await Add(SceneUtility.SceneInGroupToSceneName(stageGroup, number), sceneData);
        }

        /*
        public SceneInfo GetCurrentMainScene()
        {

        }
        */
    }

    public class SceneInfo
    {
        public bool IsInGroup;
        public Scenes SceneEnum;
        public SceneGroups SceneGroupEnum;
        public int Number;

        /*
        public SceneInfo(bool isInGroup, SceneEnum sceneEnum, SceneGroupEnum sceneGroupEnum, int number)
        {
            IsInGroup = isInGroup;
            SceneEnum = sceneEnum;
            SceneGroupEnum = sceneGroupEnum;
            Number = number;
        }
        */
    }

}