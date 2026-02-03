using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{

    public interface IConsumable { }

    [Serializable]
    public class Food : Item, IUsable, IShellable, IConsumable
    {
        #region Properties
        [field: SerializeField] public float HealingPoints { get; set; }
        [field: SerializeField] public float price { get; set; }
        #endregion

        #region Fields
        #endregion

        #region PublicMethods
        public void Eat()
        {
            Debug.Log("Has comido " + Name + " ganas " + HealingPoints + " vidas.");
        }

        public void Use()
        {
            Eat();
        }

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
