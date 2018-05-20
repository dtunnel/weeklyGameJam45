using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemDrop : MonoBehaviour {

    public List<GameObject> dropItems;

    // Drops random dropItem within dropItem list on destruction of enemy
    private void OnDestroy() {
        if(dropItems.Count > 0) 
            Instantiate(dropItems[Random.Range(0, dropItems.Count-1)], transform.position, Quaternion.identity);
    }

}
