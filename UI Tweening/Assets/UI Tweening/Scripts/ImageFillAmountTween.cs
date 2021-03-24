using UnityEngine.UI;

namespace UITweening
{
    /// <summary>
    /// A Tween that controls an Image's fill amount.
    /// </summary>
    public class ImageFillAmountTween : Tween
    {
        #region Fields and Properties
        private Image _target = null;
        private float _endValue = 0;
        private float _startValue = 0;
        #endregion

        #region Public Methods
        /// <summary>
        /// Starts the tween for the given target and end value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        public void Start(Image target, float endValue)
        {
            _target = target;
            _endValue = endValue;
            _startValue = target.fillAmount;
        }

        /// <summary>
        /// Updates the Tween by decreasing the lifetime and returning if the Tween should be destroyed.
        /// Changes the fill amount of the target image.
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            bool shouldRecycle = base.Update();
            _target.fillAmount = (1 - LifetimePercentage) * (_endValue - _startValue) + _startValue;
            return shouldRecycle;
        }

        /// <summary>
        /// Tells the Tween to start from the given value.
        /// </summary>
        /// <param name="startValue"></param>
        public ImageFillAmountTween From(float startValue)
        {
            _startValue = startValue;
            _target.fillAmount = _startValue;
            return this;
        }

        /// <summary>
        /// Completes and stops the Tween.
        /// </summary>
        /// <returns></returns>
        public override void Complete()
        {
            base.Complete();
            _target.fillAmount = _endValue;
        }
        #endregion
    }

    public static class ImageFillAmountTweenExtension
    {
        /// <summary>
        /// Starts Tweening this image's fill amount to the given amount.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static ImageFillAmountTween ToFillAmount(this Image target, float endValue, float duration)
        {
            var tween = TweenManager.Request<ImageFillAmountTween>(duration);
            tween.Start(target, endValue);
            return tween;
        }
    }
}