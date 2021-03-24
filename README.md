# ui-tweening
A tweening package for Unity, focused on UI.
The API was designed to work similar to DOTween.
## Installation
You can download the entire Assets/UI Tweening folder,
or just the Assets/UI Tweening/LICENSE and Assets/UI Tweening/Scripts.
The 2D Sprite, Unity UI, and TextMeshPro packages are required.
They can be installed from the Unity Package Manager.
Make sure to Import TMP Essential Resources from Window/TextMeshPro.
## Documentation
### Tweening an Image
Image.ToFillAmount(endValue, duration) is used to Tween an Image's fillAmount.
If you want to start at a particular value, you can say Image.ToFillAmount(endValue, duration).From(startValue)
The .OnComplete method for a Tween will set the OnComplete action to be called upon completion of the Tween.
This method can be chained after a .From or .ToFillAmount if there is no .From.
.Complete() will complete the Tween and stop it.
.Stop() will stop the Tween at whatever the current value is.
Image.ToAlpha(endValue, durection) will change the alpha value of an Image's color.
Image.ToColor(endValue, duration) will change an Image's color.
### Tweening a TextMeshProUGUI
TextMeshProUGUI.ToAlpha(endValue, durection) will change the alpha value of a TextMeshProUGUI's color.
TextMeshProUGUI.ToColor(endValue, duration) will change a TextMeshProUGUI's color.
### Tweening a RectTransform
RectTransform.ToPosition(endValue, duration) will change the anchoredPosition3D of a RectTransform.
RectTransform.ToRotation(endValue, duration) will change the eulerAngles of a RectTransform.
RectTransform.ToScale(endValue, duration) will change the localScale of a RectTransform.
NOTE: ToScale(endValue, duration) takes either a Vector3 scale or a float, which changes the localScale to new Vector(endValue, endValue, endValue).
### Custom Tween
You can create your own custom Tween, based on the Tween class.
Look at the implementations for the current custom Tweens to create your own.
A custom Tween is not limited to any UI or requiring tweening an object.