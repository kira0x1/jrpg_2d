using UnityEngine;

namespace Kira
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup m_MainMenuCanvas;
        private bool m_MenuOn;

        public void OnMenu()
        {
            ToggleMenu();
        }

        private void ToggleMenu()
        {
            m_MenuOn = !m_MenuOn;

            m_MainMenuCanvas.alpha = m_MenuOn ? 1f : 0f;
            m_MainMenuCanvas.interactable = m_MenuOn;
            m_MainMenuCanvas.blocksRaycasts = m_MenuOn;
        }

        //// MENU BUTTON CALLBACKS ////

        public void OnCharacterClicked()
        {
        }

        public void OnPartyClicked()
        {
        }

        public void OnSaveClicked()
        {
        }

        public void OnSettingsClicked()
        {
        }
    }
}