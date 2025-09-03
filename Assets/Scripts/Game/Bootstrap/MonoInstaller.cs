using UnityEngine;

namespace Game.Bootstrap
{
    [DefaultExecutionOrder(-8000)]
    public abstract class MonoInstaller : MonoBehaviour
    {
        private void Awake()
        {
            InstallBindings();
        }

        protected abstract void InstallBindings();
    }
}