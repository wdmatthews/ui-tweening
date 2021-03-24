using Type = System.Type;
using System.Collections.Generic;
using UnityEngine;

namespace UITweening
{
    /// <summary>
    /// A singleton to manage and update all tweens.
    /// </summary>
    [AddComponentMenu("UI Tweening/Tween Manager")]
    [DisallowMultipleComponent]
    public class TweenManager : MonoBehaviour
    {
        #region Fields and Properties
        private static TweenManager _instance = null;
        private static List<Tween> _activeTweens = new List<Tween>();
        private static Dictionary<Type, List<Tween>> _inactiveTweens = new Dictionary<Type, List<Tween>>();
        #endregion

        #region Unity Events
        private void Update()
        {
            int activeTweenCount = _activeTweens.Count;
            for (int i = activeTweenCount - 1; i >= 0; --i)
            {
                Tween tween = _activeTweens[i];
                // If the tween should be recycled, recycle it.
                if (tween.Update())
                {
                    Type type = tween.GetType();
                    if (!_inactiveTweens.ContainsKey(type)) _inactiveTweens.Add(type, new List<Tween>());
                    _inactiveTweens[type].Add(tween);
                    _activeTweens.RemoveAt(i);
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Requests a Tween, whether old or recycled.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="maxLifetime"></param>
        /// <returns></returns>
        public static T Request<T>(float maxLifetime) where T : Tween, new()
        {
            CheckForInstance();

            Type type = typeof(T);
            List<Tween> inactiveTweens = _inactiveTweens.ContainsKey(type) ? _inactiveTweens[type] : null;
            int inactiveTweensCount = inactiveTweens != null ? inactiveTweens.Count : 0;
            T newTween = null;

            if (inactiveTweensCount > 0)
            {
                newTween = (T)inactiveTweens[inactiveTweensCount - 1];
                inactiveTweens.RemoveAt(inactiveTweensCount - 1);
            }
            else newTween = new T();

            newTween.Initialize(maxLifetime);
            _activeTweens.Add(newTween);
            return newTween;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Checks if an instance of TweenManager exists, and creates one if not.
        /// </summary>
        private static void CheckForInstance()
        {
            if (!_instance)
            {
                _instance = new GameObject("Tween Manager").AddComponent<TweenManager>();
                DontDestroyOnLoad(_instance);
            }
        }
        #endregion
    }
}