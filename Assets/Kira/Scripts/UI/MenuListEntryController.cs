namespace Kira.UI
{
    using UnityEngine;
    using UnityEngine.UIElements;

    public class MenuListEntryController
    {
        Label m_Label;

        public void SetVisualElement(VisualElement visualElement)
        {
            m_Label = visualElement.Q<Label>("menu-label");
            Debug.Log("meow?");
        }

        public void SetMenuData(MenuElementData menuData)
        {
            m_Label.text = menuData.Label;
        }
    }
}