using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Inventory
{
    public class UI : MonoBehaviour
    {
        #region Fields
        // References to UI elements
        [Header("UI References")]
        [SerializeField] private ItemButton _prefabButton;
        [SerializeField] private Transform _itemPoll;
        [SerializeField] private Transform _inventoryPanel;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _sellButton;

        [Header("Inventory")]
        [SerializeField] private InventorySistem _inventory;

        [Header("Item Seleced")]
        [SerializeField] private ItemButton _currentItemSelected;

        #endregion

        #region Callbacks
        void Awake()
        {
            _useButton.onClick.AddListener(() => UseCurrentItem());
            _sellButton.onClick.AddListener(() => SellCurrentItem());
        }
        void Start()
        {

            InitializeUI();
        }

        #endregion

        #region PublicMethods

        public void AddItem(ItemButton buttonItemToAdd)
        {
            ItemButton newButtonItem = Instantiate(_prefabButton, _inventoryPanel);
            newButtonItem.CurrentItem = buttonItemToAdd.CurrentItem;
            newButtonItem.OnClick += () => SelecItem(newButtonItem);
        }

        //UI UseItem
        private void UseCurrentItem()
        {
            (_currentItemSelected.CurrentItem as IUsable).Use();
            if (_currentItemSelected.CurrentItem is IConsumable)
                Consume(_currentItemSelected);
        }
        //UI SellItem
        private void SellCurrentItem()
        {
            (_currentItemSelected.CurrentItem as IShellable).Shell();
            Consume(_currentItemSelected);
        }
        public void SelecItem(ItemButton currentItem)
        {
            _currentItemSelected = currentItem;
            //If Sellable
            if (_currentItemSelected.CurrentItem is IShellable)
                _sellButton.gameObject.SetActive(true);
            else
                _sellButton.gameObject.SetActive(false);

            //If Usable
            if (_currentItemSelected.CurrentItem is IUsable)
                _useButton.gameObject.SetActive(true);
            else
                _useButton.gameObject.SetActive(false);
        }

        #endregion

        #region PrivateMethods

        private void InitializeUI()
        {
            for (int i = 0; i < _inventory.Items.Count; i++)
            {
                ItemButton newButton = Instantiate(_prefabButton, _itemPoll);
                newButton.gameObject.SetActive(true);
                newButton.CurrentItem = _inventory.Items[i];

                newButton.OnClick += () => AddItemToInventory(newButton);
            }
            _prefabButton.gameObject.SetActive(false);
        }

        private void AddItemToInventory(ItemButton itemToAdd)
        {
            ItemButton newButton = Instantiate(_prefabButton, _inventoryPanel);
            newButton.gameObject.SetActive(true);
            newButton.CurrentItem = itemToAdd.CurrentItem;

            newButton.OnClick += () => SelecItem(newButton);
        }

        private void Consume(ItemButton currentItemSelected)
        {
            Destroy(_currentItemSelected.gameObject);
            _currentItemSelected = null;
            _sellButton.gameObject.SetActive(false);
            _useButton.gameObject.SetActive(false);
        }

        #endregion
    }
}
