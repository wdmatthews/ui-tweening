using UnityEngine;
using UnityEngine.UI;

namespace UITweening
{
    /// <summary>
    /// A Tween that controls an Image's alpha.
    /// </summary>
    public class ImageAlphaTween : Tween
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
            _startValue = target.color.a;
        }

        /// <summary>
        /// Updates the Tween by decreasing the lifetime and returning if the Tween should be destroyed.
        /// Changes the alpha of the target image.
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            bool shouldRecycle = base.Update();
            _target.SetAlpha((1 - LifetimePercentage) * (_endValue - _startValue) + _startValue);
            return shouldRecycle;
        }

        /// <summary>
        /// Tells the Tween to start from the given value.
        /// </summary>
        /// <param name="startValue"></param>
        public ImageAlphaTween From(float startValue)
        {
            _startValue = startValue;
            _target.SetAlpha(_startValue);
            return this;
        }

        /// <summary>
        /// Completes and stops the Tween.
        /// </summary>
        /// <returns></returns>
        public override void Complete()
        {
            base.Complete();
            _target.SetAlpha(_endValue);
        }
        #endregion
    }

    public static class ImageAlphaTweenExtension
    {
        /// <summary>
        /// Starts Tweening this image's alpha to the given amount.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="endValue"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static ImageAlphaTween ToAlpha(this Image target, float endValue, float duration)
        {
            var tween = TweenManager.Request<ImageAlphaTween>(duration);
            tween.Start(target, endValue);
            return tween;
        }

        /// <summary>
        /// Sets the alpha value of this image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="alpha"></param>
        public static void SetAlpha(this Image image, float alpha)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }
    }
}