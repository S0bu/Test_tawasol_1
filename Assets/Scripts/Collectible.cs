using Photon.Pun;
using System;
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
    [SerializeField] private Transform parent;

    GameObject temp;
    PhotonView view;
    
    void OnEnable()
    {
        Items.collectedItems.Clear();
        Items.droppedItems.Clear();

        view = GetComponent<PhotonView>();

        //parent = transform.Find("Balls").GetComponent<Transform>();
    }


    void Update()
    {
        try
        {
            if (view.IsMine)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (Items.collectedItems.Count == 0)
                    {
                        temp = PhotonNetwork.Instantiate("Collectible", transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
                        temp.transform.SetParent(parent);
                    }
                    else
                    {
                        temp = Items.collectedItems[0];
                        Items.collectedItems.RemoveAt(0);
                    }
                    temp.SetActive(true);
                    temp.GetComponent<Rigidbody>().AddForce(transform.forward * 1.2f, ForceMode.Impulse);

                    Items.droppedItems.Add(temp);
                    temp = null;
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }
        
    }

    #region if_able_to_collect
    /*    private void OnCollisionEnter(Collision collision)
        {
            print($"Collision {gameObject}  {collision.gameObject}");
            if (collision.gameObject.CompareTag("Collectible"))
            {
                temp = collision.gameObject;
                temp.SetActive(false);

                Items.collectedItems.Add(temp);
                Items.droppedItems.Remove(temp);
            }
        }*/
    #endregion
}
