using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour {

    public List<GameObject> dropItems;

    // Drops random dropItem within dropItem list on destruction of enemy
    private void OnDestroy() {
        GameObject newItem;
        int itemIndex;
        if (dropItems.Count > 0) {
            itemIndex = Random.Range(0, dropItems.Count - 1);
            newItem = (GameObject)Instantiate(dropItems[itemIndex], transform.position, Quaternion.identity);
            newItem.name = dropItems[itemIndex].name;
        }
    }

}
