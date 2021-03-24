using UnityEngine;

namespace UITweening
{
    /// <summary>
    /// A Tween that controls a RectTransform's scale.
    /// </summary>
    public class RectTransformScaleTween : Tween
    {
        #region Fields and Properties
        private RectTransform _target = null;
        private Vector3 _endValue = new Vector3();
        private Vector3 _startValue = new Vector3();
        #endregion

        #region Public Methods
        /// <summary>
        /// Starts the tween for the given target and end value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        public void Start(RectTransform target, Vector3 endValue)
        {
            _target = target;
            _endValue = endValue;
            _startValue = target.localScale;
        }

        /// <summary>
        /// Updates the Tween by decreasing the lifetime and returning if the Tween should be destroyed.
        /// Changes the scale of the target transform.
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            bool shouldRecycle = base.Update();
            float percent = 1 - LifetimePercentage;
            _target.localScale = new Vector3(
                percent * (_endValue.x - _startValue.x) + _startValue.x,
                percent * (_endValue.y - _startValue.y) + _startValue.y,
                percent * (_endValue.z - _startValue.z) + _startValue.z);
            return shouldRecycle;
        }

        /// <summary>
        /// Tells the Tween to start from the given value.
        /// </summary>
        /// <param name="startValue"></param>
        public RectTransformScaleTween From(Vector3 startValue)
        {
            _startValue = startValue;
            _target.localScale = _startValue;
            return this;
        }

        /// <summary>
        /// Completes and stops the Tween.
        /// </summary>
        /// <returns></returns>
        public override void Complete()
        {
            base.Complete();
            _target.localScale = _endValue;
        }
        #endregion
    }

    public static class RectTransformScaleTweenExtension
    {
        /// <summary>
        /// Starts Tweening this transform's scale to the given scale.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static RectTransformScaleTween ToScale(this RectTransform target, Vector3 endValue, float duration)
        {
            var tween = TweenManager.Request<RectTransformScaleTween>(duration);
            tween.Start(target, endValue);
            return tween;
        }

        /// <summary>
        /// Starts Tweening this transform's scale to the given scale.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static RectTransformScaleTween ToScale(this RectTransform target, float endValue, float duration)
        {
            var tween = TweenManager.Request<RectTransformScaleTween>(duration);
            tween.Start(target, new Vector3(endValue, endValue, endValue));
            return tween;
        }
    }
}