using UnityEngine;

namespace Kira
{
    using UI;
    using UnityEngine.UIElements;

    public class PlayerUI : MonoBehaviour
    {
        [SerializeField]
        private UIDocument m_Doc;

        [SerializeField]
        private VisualTreeAsset m_ListEntryTemplate;

        private VisualElement m_MenuElement;

        private void OnEnable()
        {
            var menuListController = new MenuListController();
            menuListController.InitMenuList(m_Doc.rootVisualElement, m_ListEntryTemplate);
        }

        private void Start()
        {
            m_MenuElement = m_Doc.rootVisualElement.Q<VisualElement>("menu-container");
            var menuListController = new MenuListController();
            menuListController.InitMenuList(m_Doc.rootVisualElement, m_ListEntryTemplate);
        }

        public void OnMenu()
        {
            ToggleMenu();
        }

        public void ToggleMenu()
        {
            m_MenuElement.visible = !m_MenuElement.visible;
        }
    }
}