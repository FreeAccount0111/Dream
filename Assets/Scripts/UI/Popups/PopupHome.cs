using Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PopupHome : BasePopup
    {
        [SerializeField] private Button btnPlay, btnGuid;

        private void Awake()
        {
            btnPlay.onClick.AddListener(() =>
            {
                /*CircleOutline.Instance.ScaleIn(() =>
                {
                    HideImmediately(true);
                    SceneManager.LoadSceneAsync($"Gameplay");
                });*/
                
                HideImmediately(true);
                PopupCtrl.Instance.GetPopupByType<PopupLevel>().ShowImmediately(false);
                //Loader.LoadScene(Loader.Scene.Gameplay);
            });

            btnGuid.onClick.AddListener(() =>
            {
                PopupCtrl.Instance.GetPopupByType<PopupGuid>().ShowImmediately(true);
                HideImmediately(true);
            });
        }
    }
}
