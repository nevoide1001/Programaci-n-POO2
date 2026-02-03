using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Inventory
{
    public interface IShellable
    {
        #region Properties
        public float price { get; set; }
        #endregion

        #region PublicMethods
        public float Shell();
        #endregion
    }
}
