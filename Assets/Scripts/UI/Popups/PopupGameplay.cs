using System;
using System.Collections.Generic;
using Gameplay;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PopupGameplay : BasePopup
    {
        [SerializeField] private Button btnHome, btnReplay;

        private void Awake()
        {
            btnHome.onClick.AddListener(() =>
            {
                CircleOutline.Instance.ScaleIn(() =>
                {
                    PopupCtrl.Instance.HideAllPopup();
                    PopupCtrl.Instance.GetPopupByType<PopupHome>().ShowImmediately(true);
                    SceneManager.LoadSceneAsync("MainMenu");
                    CircleOutline.Instance.ScaleOut();
                });
            });
            
            btnReplay.onClick.AddListener(() =>
            {
                CircleOutline.Instance.ScaleIn(() =>
                {
                    SceneManager.LoadScene("Gameplay");
                    CircleOutline.Instance.ScaleOut();
                });
            });
        }
    }
}
