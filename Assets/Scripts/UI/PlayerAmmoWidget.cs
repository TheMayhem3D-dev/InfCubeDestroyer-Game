using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace UI
{
    public class PlayerAmmoWidget : EventEntity
    {
        [SerializeField] private Sprite ammoSprite;
        [SerializeField] private Vector2 ammoSpriteSize;
        [SerializeField] private Vector2 ammoSpriteStartPos;
        [SerializeField] private float ammoSpritePosStep;

        private GameObject[] ammoImages;

        public override void Subscribe()
        {
            if (GameEvents.main != null)
            {
                GameEvents.main.onAmmoCountStarted += CreateAmmoUI;
                GameEvents.main.onAmmoCountChanged += UpdateAmmoCount;
            }
            else
                throw new MissingReferenceException();
        }

        public override void Unsubscribe()
        {
            if (GameEvents.main != null)
            {
                GameEvents.main.onAmmoCountStarted -= CreateAmmoUI;
                GameEvents.main.onAmmoCountChanged -= UpdateAmmoCount;
            }
        }

        private void CreateAmmoUI(int amount)
        {
            ammoImages = new GameObject[amount];
            for (int i = 0; i < amount; i++)
            {
                GameObject imgObject = new GameObject("AmmoImage");

                RectTransform trans = imgObject.AddComponent<RectTransform>();
                trans.transform.SetParent(transform);
                trans.localScale = Vector3.one;
                trans.anchoredPosition = new Vector2(ammoSpriteStartPos.x + (ammoSpritePosStep * i), ammoSpriteStartPos.y);
                trans.sizeDelta = ammoSpriteSize;

                Image image = imgObject.AddComponent<Image>();
                image.sprite = ammoSprite;
                ammoImages[i] = imgObject;
            }
        }

        private void UpdateAmmoCount(int amount)
        {
            if (ammoImages != null)
            {
                for (int i = 0; i < ammoImages.Length; i++)
                {
                    ammoImages[i].SetActive(false);
                }

                for (int i = 0; i < amount; i++)
                {
                    ammoImages[i].SetActive(true);
                }
            }
            else
                throw new MissingReferenceException();
        }
    }
}