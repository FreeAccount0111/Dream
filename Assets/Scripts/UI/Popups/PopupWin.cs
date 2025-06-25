using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PopupWin : BasePopup
    {
        [SerializeField] private Button btnReplay, btnHome, btnNext;
        [SerializeField] private Text txtScore;

        private void Awake()
        {
            btnReplay.onClick.AddListener(() =>
            {
                CircleOutline.Instance.ScaleIn(() =>
                {
                    PopupCtrl.Instance.HideAllPopup();
                    PopupCtrl.Instance.GetPopupByType<PopupGameplay>().ShowImmediately(true);
                    SceneManager.LoadScene("Gameplay");
                    CircleOutline.Instance.ScaleOut();
                });
            });

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
            
            btnNext.onClick.AddListener(() =>
            {
                CircleOutline.Instance.ScaleIn(() =>
                {
                    HideImmediately(true);
                    CircleOutline.Instance.ScaleOut();
                });
            });
        }

        public void UpdateScore(int score)
        {
            txtScore.text = score.ToString();
        }
    }
}
