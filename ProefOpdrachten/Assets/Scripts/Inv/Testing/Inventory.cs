using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public Dictionary<Item, int> items = new Dictionary<Item, int>();
    private List<IObserver> observers = new List<IObserver>();

    public void AddItem(Item item) {
        if (items.ContainsKey(item)) {
            items[item]++;
        } else {
            items[item] = 1;
        }
        NotifyObservers();  // Notify UI of the change
    }

    public void AddItem(IObserver observer) {
        observers.Add(observer);
    }

    public void RemoveItem(IObserver observer) {
        observers.Remove(observer);
    }

    private void NotifyObservers() {
        foreach (var observer in observers) {
            observer.OnInventoryChanged(items);
        }
    }
}