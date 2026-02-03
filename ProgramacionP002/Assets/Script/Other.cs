using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class Other : Item, IShellable
    {
        #region Properties
        [field: SerializeField] public float price { get; set; }
        #endregion

        #region PublicMethods
        public float Shell()
        {
            Debug.Log("Has ganado" + price + "Coins");
            return price;
        }
        #endregion

        #region PrivateMethods
        #endregion
    }
}
