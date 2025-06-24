using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopupLose : BasePopup
    {
        [SerializeField] private Button btnHome, btnReplay;

        private void Awake()
        {
            btnHome.onClick.AddListener(() =>
            {
                CircleOutline.Instance.ScaleIn(() =>
                {
                    HideImmediately(true);
                    PopupCtrl.Instance.GetPopupByType<PopupHome>().ShowImmediately(false);
                    CircleOutline.Instance.ScaleOut();
                });
            });

            btnReplay.onClick.AddListener(() =>
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
