using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelBtn : MonoBehaviour
    {
        [SerializeField] private Button btn;
        [SerializeField] private TMP_Text txtLevel;
        [SerializeField] private Sprite spriteLock, spriteDefault;
    

        public void AddListener(Action action)
        {
            btn.onClick.AddListener(() =>
            {
                action?.Invoke();
            });
        }

        public void SetLevelBtn(int index)
        {
            txtLevel.text = (index + 1).ToString();
            if (UserData.GetLevelLock((index)))
            {
                txtLevel.gameObject.SetActive(false);
                btn.image.sprite = spriteLock;
            }
            else
            {
                txtLevel.gameObject.SetActive(true);
                btn.image.sprite = spriteDefault;
            }
        }
    }
}
