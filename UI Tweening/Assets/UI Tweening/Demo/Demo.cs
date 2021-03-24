using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UITweening.Demo
{
    [AddComponentMenu("UI Tweening/Demo")]
    [DisallowMultipleComponent]
    public class Demo : MonoBehaviour
    {
        #region Fields and Properties
        [SerializeField] private float _animationDuration = 0.25f;
        [SerializeField] private Image _fill = null;
        [SerializeField] private TextMeshProUGUI _text = null;
        [SerializeField] private RectTransform _box = null;
        #endregion

        #region Public Methods
        public void Fill()
        {
            if (Mathf.Approximately(_fill.fillAmount, 0))
            {
                // Start filling the image to 1 (full),
                // making sure it starts at a random value.
                // Additionally, add a callback to state completion of the Tween.
                // NOTE: The methods have to be in this order.
                // From is optional, and so is OnComplete,
                // but From must come before OnComplete if both are used,
                // because OnComplete does not return the Tween.
                _fill.ToFillAmount(1, _animationDuration)
                    .From(Random.Range(0.25f, 0.5f))
                    .OnComplete(() => Debug.Log("Fill completed!"));
            }
            else if (Mathf.Approximately(_fill.fillAmount, 1))
            {
                _fill.ToFillAmount(0, _animationDuration).From(1);
            }
        }

        public void Fade()
        {
            if (Mathf.Approximately(_fill.color.a, 0))
            {
                _fill.ToAlpha(1, _animationDuration);
            }
            else if (Mathf.Approximately(_fill.color.a, 1))
            {
                _fill.ToAlpha(0, _animationDuration);
            }
        }

        public void Color()
        {
            _fill.ToColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)), _animationDuration);
        }

        public void TextFade()
        {
            if (Mathf.Approximately(_text.color.a, 0))
            {
                _text.ToAlpha(1, _animationDuration);
            }
            else if (Mathf.Approximately(_text.color.a, 1))
            {
                _text.ToAlpha(0, _animationDuration);
            }
        }

        public void TextColor()
        {
            _text.ToColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)), _animationDuration);
        }

        public void Move()
        {
            _box.ToPosition(new Vector3(Random.Range(-48f, 48f), Random.Range(-72f, -24f), 0), _animationDuration);
        }

        public void Rotate()
        {
            _box.ToRotation(new Vector3(0, 0, Random.Range(-180, 180)), _animationDuration);
        }

        public void Scale()
        {
            _box.ToScale(Random.Range(0.1f, 1), _animationDuration);
        }
        #endregion
    }
}