using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventorySistem : MonoBehaviour
    {
        #region Properties
        
        #endregion

        #region Fields

        [Header("Object Definition")]
        [SerializeField] private Weapon[] _weapons;
        [SerializeField] private Food[] _foods;
        [SerializeField] private Other[] _others;

        [Header("Item Pool")]
        [SerializeField] private List<Item> _items = new List<Item>();
        public List<Item> Items => _items;

        #endregion

        #region Callbacks
        void Awake()
        {

            InitializeItems();
           
        }
        #endregion

        #region PublicMethods
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
        
        #endregion
    }
}
