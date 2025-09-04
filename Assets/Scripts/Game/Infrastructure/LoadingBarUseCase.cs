using System;
using System.Threading;
using System.Threading.Tasks;
using Game.Application.Interfaces;
using Game.Application.UseCases;
using Game.Domain.Entities;
using UnityEngine;

namespace Game.Infrastructure
{
    public class LoadingBarUseCase : ILoadingBarUseCase
    {
        private CancellationTokenSource _cancellationTokenSource;

        public void Execute(ILoadingBar loadingBar, float targetProgress, ILoadingBarCallback loadingBarCallback)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource?.Dispose();
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _ = HandleProgress(_cancellationTokenSource.Token, loadingBar, targetProgress,
                loadingBarCallback);
        }

        private async Task HandleProgress(CancellationToken token, ILoadingBar loadingBar, float targetProgress,
            ILoadingBarCallback loadingBarCallback)
        {
            try
            {
                var currentProgress = loadingBar.Value;
                var t = 0f;
                while (t <= .25f)
                {
                    token.ThrowIfCancellationRequested();
                    t += Time.deltaTime;
                    var nextProgress = Mathf.Lerp(currentProgress, targetProgress, t / .25f);
                    loadingBar.Value = nextProgress;
                    await Task.Yield();
                    loadingBarCallback.UpdateProgress(nextProgress);
                }

                loadingBarCallback.UpdateProgress(targetProgress);
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Debug.Log(operationCanceledException.Message);
            }
        }
    }
}