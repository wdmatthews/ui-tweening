using UnityEngine;
using UnityEngine.UI;

namespace UITweening
{
    /// <summary>
    /// A Tween that controls an Image's color.
    /// </summary>
    public class ImageColorTween : Tween
    {
        #region Fields and Properties
        private Image _target = null;
        private Color _endValue = new Color(1, 1, 1);
        private Color _startValue = new Color(1, 1, 1);
        #endregion

        #region Public Methods
        /// <summary>
        /// Starts the tween for the given target and end value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        public void Start(Image target, Color endValue)
        {
            _target = target;
            _endValue = endValue;
            _startValue = target.color;
        }

        /// <summary>
        /// Updates the Tween by decreasing the lifetime and returning if the Tween should be destroyed.
        /// Changes the color of the target image.
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            bool shouldRecycle = base.Update();
            float percent = 1 - LifetimePercentage;
            _target.color = new Color(
                percent * (_endValue.r - _startValue.r) + _startValue.r,
                percent * (_endValue.g - _startValue.g) + _startValue.g,
                percent * (_endValue.b - _startValue.b) + _startValue.b,
                percent * (_endValue.a - _startValue.a) + _startValue.a);
            return shouldRecycle;
        }

        /// <summary>
        /// Tells the Tween to start from the given value.
        /// </summary>
        /// <param name="startValue"></param>
        public ImageColorTween From(Color startValue)
        {
            _startValue = startValue;
            _target.color = _startValue;
            return this;
        }

        /// <summary>
        /// Completes and stops the Tween.
        /// </summary>
        /// <returns></returns>
        public override void Complete()
        {
            base.Complete();
            _target.color = _endValue;
        }
        #endregion
    }

    public static class ImageColorTweenExtension
    {
        /// <summary>
        /// Starts Tweening this image's color to the given color.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static ImageColorTween ToColor(this Image target, Color endValue, float duration)
        {
            var tween = TweenManager.Request<ImageColorTween>(duration);
            tween.Start(target, endValue);
            return tween;
        }
    }
}