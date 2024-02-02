using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for object pooling
abstract class Items
{
    public static List<GameObject> droppedItems = new();
    public static List<GameObject> collectedItems = new();
}

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab;
    
    void Start()
    {
        Items.collectedItems.Clear();
        Items.droppedItems.Clear();
    }


    void Update()
    {
        
    }
}
