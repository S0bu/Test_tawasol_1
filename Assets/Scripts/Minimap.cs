using System.Collections;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Transform player;

    private IEnumerator Start()
    {
        player = GameObject.Find("Player").transform.GetChild(0);
        while(player == null)
            yield return null;
    }
    void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
