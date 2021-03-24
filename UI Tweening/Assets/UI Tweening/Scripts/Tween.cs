using UnityEngine;

namespace UITweening
{
    /// <summary>
    /// Provides the base behaviour for a Tween.
    /// </summary>
    public abstract class Tween
    {
        #region Fields and Properties
        private float _lifetime = 0;
        private float _maxLifetime = 0;
        protected float LifetimePercentage => _lifetime / _maxLifetime;
        /// <summary>
        /// Set this true to mark the Tween for recycling.
        /// </summary>
        protected bool _shouldRecycle = false;
        private System.Action _onComplete = null;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes the Tween with a certain lifetime.
        /// </summary>
        /// <param name="maxLifetime"></param>
        public void Initialize(float maxLifetime)
        {
            _maxLifetime = maxLifetime;
            _lifetime = _maxLifetime;
            _shouldRecycle = false;
        }

        /// <summary>
        /// Updates the Tween by decreasing the lifetime and returning if the Tween should be destroyed.
        /// </summary>
        /// <returns></returns>
        public virtual bool Update()
        {
            if (_shouldRecycle) return true;
            if (Mathf.Approximately(_lifetime, 0))
            {
                Complete();
                return true;
            }
            else _lifetime = Mathf.Clamp(_lifetime - Time.deltaTime, 0, _maxLifetime);
            return false;
        }

        /// <summary>
        /// Immediately stops the Tween and marks it for recycling.
        /// </summary>
        public void Stop()
        {
            _shouldRecycle = true;
            _onComplete = null;
        }

        /// <summary>
        /// Completes and stops the Tween.
        /// </summary>
        public virtual void Complete()
        {
            _onComplete?.Invoke();
            _onComplete = null;
        }

        public void OnComplete(System.Action onComplete) => _onComplete = onComplete;
        #endregion
    }
}