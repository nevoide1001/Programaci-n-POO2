using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class Weapon : Item, IUsable
    {
        #region Properties
        [field: SerializeField] public float Damage { get; set; }
        #endregion

        #region Fields
        #endregion

        #region PublicMethods
        public void Attack()
        {
            Debug.Log("Do Attack " + Damage + " de daño.");
        }

        public void Use()
        {
            Attack();
        }
        #endregion

        #region PrivateMethods
        #endregion
    }
}
