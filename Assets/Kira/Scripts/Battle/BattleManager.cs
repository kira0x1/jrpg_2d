namespace Kira
{
    using System.Collections;
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.Serialization;

    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup transitionCanvas;
        [FormerlySerializedAs("transitionTime"), SerializeField, Range(0, 5f)] private float minTransitionTime = 1.0f;
        [SerializeField] private TextMeshProUGUI transitionText;

        private float curTransitionTime;

        public void InitiateBattle()
        {
            transitionCanvas.alpha = 1f;
            transitionCanvas.blocksRaycasts = true;

            StartCoroutine(HandleTransition());
        }

        private IEnumerator HandleTransition()
        {
            curTransitionTime = 0f;
            Scene activeScene = SceneManager.GetActiveScene();
            Debug.Log($"active scene: {activeScene.name}");
            AsyncOperation sceneTask = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            if (sceneTask == null)
            {
                Debug.LogError("SceneTask Null");
                yield break;
            }

            sceneTask.allowSceneActivation = false;

            while (curTransitionTime < minTransitionTime || sceneTask.progress < 0.9f)
            {
                if (curTransitionTime < minTransitionTime)
                {
                    curTransitionTime += Time.deltaTime;
                    transitionText.text = $"Loading {(curTransitionTime / minTransitionTime) * 100:F1}%";
                }
                else
                {
                    curTransitionTime = sceneTask.progress;
                    transitionText.text = $"Loading {curTransitionTime * 100:F1}%";
                }

                yield return null;
            }

            SceneManager.UnloadSceneAsync(activeScene);
            sceneTask.allowSceneActivation = true;
            OnTransitionDone();
        }


        private void OnTransitionDone()
        {
            transitionCanvas.alpha = 0f;
            transitionCanvas.blocksRaycasts = false;
        }
    }
}