using UnityEngine;

namespace UITweening
{
    /// <summary>
    /// A Tween that controls a RectTransform's position.
    /// </summary>
    public class RectTransformPositionTween : Tween
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
            _startValue = target.anchoredPosition3D;
        }

        /// <summary>
        /// Updates the Tween by decreasing the lifetime and returning if the Tween should be destroyed.
        /// Changes the position of the target transform.
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            bool shouldRecycle = base.Update();
            float percent = 1 - LifetimePercentage;
            _target.anchoredPosition3D = new Vector3(
                percent * (_endValue.x - _startValue.x) + _startValue.x,
                percent * (_endValue.y - _startValue.y) + _startValue.y,
                percent * (_endValue.z - _startValue.z) + _startValue.z);
            return shouldRecycle;
        }

        /// <summary>
        /// Tells the Tween to start from the given value.
        /// </summary>
        /// <param name="startValue"></param>
        public RectTransformPositionTween From(Vector3 startValue)
        {
            _startValue = startValue;
            _target.anchoredPosition3D = _startValue;
            return this;
        }

        /// <summary>
        /// Completes and stops the Tween.
        /// </summary>
        /// <returns></returns>
        public override void Complete()
        {
            base.Complete();
            _target.anchoredPosition3D = _endValue;
        }
        #endregion
    }

    public static class RectTransformPositionTweenExtension
    {
        /// <summary>
        /// Starts Tweening this transform's position to the given position.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static RectTransformPositionTween ToPosition(this RectTransform target, Vector3 endValue, float duration)
        {
            var tween = TweenManager.Request<RectTransformPositionTween>(duration);
            tween.Start(target, endValue);
            return tween;
        }
    }
}