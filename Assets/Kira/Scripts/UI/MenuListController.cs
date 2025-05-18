namespace Kira.UI
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class MenuListController
    {
        // UXML template for list entries
        VisualTreeAsset m_ListEntryTemplate;

        // UI Element References
        ListView m_MenuList;

        List<MenuElementData> m_MenuListData;

        public void InitMenuList(VisualElement root, VisualTreeAsset listElementTemplate)
        {
            EnumerateMenuList();
            m_ListEntryTemplate = listElementTemplate;
            m_MenuList = root.Q<ListView>("menu-list");
            FillMenuList();
        }

        private void EnumerateMenuList()
        {
            m_MenuListData = new List<MenuElementData>();
            m_MenuListData.Add(new MenuElementData("Character"));
            m_MenuListData.Add(new MenuElementData("Settings"));
        }

        private void FillMenuList()
        {
            m_MenuList.makeItem = () =>
            {
                var newListEntry = m_ListEntryTemplate.Instantiate();

                var newListEntryLogic = new MenuListEntryController();
                newListEntry.userData = newListEntryLogic;
                newListEntryLogic.SetVisualElement(newListEntry);

                return newListEntry;
            };

            m_MenuList.bindItem = (item, index) =>
            {
                (item.userData as MenuListEntryController)?.SetMenuData(m_MenuListData[index]);
            };

            m_MenuList.fixedItemHeight = 45;
            m_MenuList.itemsSource = m_MenuListData;
            m_MenuList.focusable = false;
            m_MenuList.delegatesFocus = false;
        }
    }
}