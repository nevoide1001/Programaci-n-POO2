using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Inventory
{
    public class ItemButton : MonoBehaviour
    {
        #region Properties
        public Item CurrentItem
        {
            get
            { 
                return _currentItem;
            }
            set
            { 
                _currentItem = value;
                _buttonText.text = _currentItem.Name;
            }
        }

        public event Action OnClick;
        #endregion

        #region Fields
        private TextMeshProUGUI _buttonText;
        private Button _button;
        private Item _currentItem;
        #endregion

        #region Callbacks
        void Awake()
        {
            _button = GetComponent<Button>();
            _buttonText = GetComponentInChildren<TextMeshProUGUI>();
            _button.onClick.AddListener(() => OnClick?.Invoke());
        }
        #endregion

        #region PublicMethods
        #endregion

        #region PrivateMethods
        #endregion
    }
}
