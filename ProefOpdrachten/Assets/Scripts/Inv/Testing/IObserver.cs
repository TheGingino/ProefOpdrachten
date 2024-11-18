using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver {
    void OnInventoryChanged(Dictionary<Item, int> updatedItems);
}
