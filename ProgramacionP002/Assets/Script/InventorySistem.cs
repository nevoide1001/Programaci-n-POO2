using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySistem : MonoBehaviour
    {
        #region Properties
        #endregion

        #region Fields
        [Header("UI References")]
        [SerializeField] private ItemButton _prefabButton;
        [SerializeField] private Transform _inventoryPanel;
        [SerializeField] private Button _useButton;
        [SerializeField] private Button _sellButton;

        [Header("Object Definition")]
        [SerializeField] private Weapon[] _weapons;
        [SerializeField] private Food[] _foods;
        [SerializeField] private Other[] _others;

        [Header("Item Pool")]
        [SerializeField] private List<Item> _items = new List<Item>();

        [Header("Item Seleced")]
        [SerializeField] private ItemButton _currentItemSelected;

        #endregion

        #region Callbacks
        void Start()
        {
            InitializeItems();
            InitializeUI();

            _useButton.onClick.AddListener(UseCurrentItem);
            _sellButton.onClick.AddListener(SellCurrentItem);
        }
        #endregion

        #region PublicMethods
        public void AddItem(ItemButton buttonItemToAdd)
        {
            ItemButton newButtonItem = Instantiate(buttonItemToAdd, _inventoryPanel);
            newButtonItem.CurrentItem = buttonItemToAdd.CurrentItem;
            newButtonItem.OnClick += () => SelecItem(newButtonItem);
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
        private void InitializeItems()
        {
            //Weapons
            for (int i = 0; i < _weapons.Length; i++)
                _items.Add(_weapons[i]);

            //Food
            for (int i = 0; i < _foods.Length; i++)
                _items.Add(_foods[i]);

            //Other
            for (int i = 0; i < _others.Length; i++)
                _items.Add(_others[i]);
        }
        private void InitializeUI()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                ItemButton newButton = Instantiate(_prefabButton, _prefabButton.transform.parent);
                newButton.CurrentItem = _items[i];
                newButton.OnClick += () => AddItem(newButton);
            }
            _prefabButton.gameObject.SetActive(false);
        }

        private void SellCurrentItem()
        {
            (_currentItemSelected.CurrentItem as IShellable).Shell();
            Consume(_currentItemSelected);
        }
        private void UseCurrentItem()
        {
            (_currentItemSelected.CurrentItem as IUsable).Use();
            if (_currentItemSelected.CurrentItem is IConsumable)
                Consume(_currentItemSelected);
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
