﻿using UnityEngine;
using UnityEngine.UI;

namespace UnityTools.UI
{
    public class ProgressBar : ProgressBarBase
    {
        [SerializeField] private Image _proggressBarImage;
        [SerializeField] private ProgressBarOrientation _orientation;

        private float _sourceWidth;

        private bool leftRigh => _orientation == ProgressBarOrientation.LeftRight;

        private void Awake()
        {
            _sourceWidth = leftRigh ? _proggressBarImage.rectTransform.rect.width : _proggressBarImage.rectTransform.rect.height;
        }

        public override void SetProgress(float value)
        {
            value = Mathf.Clamp01(value);
            var right = Mathf.Lerp(0, _sourceWidth, value);

            _proggressBarImage.rectTransform.offsetMax = leftRigh ?
                new Vector2(-right, _proggressBarImage.rectTransform.offsetMax.y) :
                new Vector2(_proggressBarImage.rectTransform.offsetMax.x, -right);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}