using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopupWin : BasePopup
    {
        [SerializeField] private Button btnReplay, btnHome, btnNext;

        private void Awake()
        {
            btnReplay.onClick.AddListener(() =>
            {
                CircleOutline.Instance.ScaleIn(() =>
                {
                    HideImmediately(true);
                    CircleOutline.Instance.ScaleOut();
                });
            });

            btnHome.onClick.AddListener(() =>
            {
                CircleOutline.Instance.ScaleIn(() =>
                {
                    HideImmediately(true);
                    PopupCtrl.Instance.GetPopupByType<PopupHome>().ShowImmediately(false);
                    CircleOutline.Instance.ScaleOut();
                });
            });
            
            btnNext.onClick.AddListener(() =>
            {
                CircleOutline.Instance.ScaleIn(() =>
                {
                    HideImmediately(true);
                    CircleOutline.Instance.ScaleOut();
                });
            });
        }
    }
}
