using System;
using System.Collections;
using System.Threading.Tasks;
using Game.Application.UseCases;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Presentation
{
    public class LoadingManager : MonoBehaviour, ILoadingView
    {
        public string defaultScene;
        public static LoadingManager Instance;

        public static event Action OnLoadComplete;

        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private TextMeshProUGUI loadingText;
        [SerializeField] private Image loadingBackground;

        private ILoadingPresenter _loadingPresenter;
        private ILoadingBarView _loadingBarView;


        public void Init(ILoadingPresenter loadingPresenter, ILoadingBarView loadingBarView)
        {
            _loadingPresenter = loadingPresenter;
            _loadingBarView = loadingBarView;
        }

        private void Awake()
        {
            if (Instance != null && Instance == this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            //
            _loadingPresenter.ApplyTheme();
        }

        private void Start()
        {
            LoadSceneAdditive(defaultScene);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            StartCoroutine(LoadSceneAdditiveAsync(sceneName));
            //_ = FakeTask();
        }

        private async Task FakeTask()
        {
            _loadingBarView.Value = 0f;
            await Task.Delay(500);
            _loadingBarView.Value = .25f;
            await Task.Delay(500);
            _loadingBarView.Value = .5f;
            await Task.Delay(1500);
            _loadingBarView.Value = .75f;
            await Task.Delay(2500);
            _loadingBarView.Value = 1f;
        }

        public void LoadSceneByName(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            loadingScreen.SetActive(true);
            _loadingBarView.Value = 0;

            var operation = SceneManager.LoadSceneAsync(sceneName);
            operation!.allowSceneActivation = false;

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / 0.9f);
                _loadingPresenter.UpdateProgress(progress);
                _loadingBarView.Value = _loadingPresenter.GetProgress();
                //
                if (operation.progress >= 0.9f)
                {
                    _loadingPresenter.FinishLoading();
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }

            loadingScreen.SetActive(false);
            Debug.Log($"Scene '{sceneName}' loaded successfully.");
        }

        private IEnumerator LoadSceneAdditiveAsync(string sceneName)
        {
            loadingScreen.SetActive(true);
            _loadingBarView.Value = 0;

            var operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            operation!.allowSceneActivation = false;

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / 0.9f);
                _loadingPresenter.UpdateProgress(progress);
                _loadingBarView.Value = _loadingPresenter.GetProgress();
                //
                if (operation.progress >= 0.9f)
                {
                    _loadingPresenter.FinishLoading();
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }

            // Example: set "MainScene" as default active scene 
            var scene = SceneManager.GetSceneByName(sceneName);
            if (scene.IsValid())
            {
                SceneManager.SetActiveScene(scene);
                Debug.Log("Active Scene set to: " + scene.name);
            }
            else
            {
                Debug.LogWarning("Scene not found or not loaded: MainScene");
            }

            OnLoadComplete?.Invoke();
            loadingScreen.SetActive(false);
            Debug.Log($"Scene '{sceneName}' loaded additively.");
        }

        public void UnloadScene(string sceneName)
        {
            StartCoroutine(UnloadSceneAsync(sceneName));
        }

        private IEnumerator UnloadSceneAsync(string sceneName)
        {
            var operation = SceneManager.UnloadSceneAsync(sceneName);
            while (!operation!.isDone)
            {
                yield return null;
            }

            Debug.Log($"Scene '{sceneName}' unloaded.");
        }

        private void ChangeTheme(ThemeDto theme)
        {
            //ApplyTheme(theme);
        }

        public void OnEnable() => _loadingPresenter.ChangeThemeUseCase.OnChangeTheme += ChangeTheme;
        public void OnDisable() => _loadingPresenter.ChangeThemeUseCase.OnChangeTheme -= ChangeTheme;

        public void ApplyTheme(ThemeDto theme)
        {
            /*loadingBackground.color = ColorUtility.TryParseHtmlString(theme.BackgroundColor, out var bgColor)
                ? bgColor
                : Color.white;*/
        }
    }
}