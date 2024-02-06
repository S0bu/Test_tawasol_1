using Cinemachine;
using System.Collections;
using UnityEngine;

public class AssignPlayer : MonoBehaviour
{
    private CinemachineFreeLook cfl;
    void Start()
    {
        cfl = GetComponent<CinemachineFreeLook>();

        StartCoroutine(nameof(assigning));
    }

    private IEnumerator assigning()
    {
        yield return new WaitForSeconds(1);
        cfl.Follow = GameObject.Find("Player").transform.GetChild(0);
        cfl.LookAt = GameObject.Find("Player").transform.GetChild(0);
    }
}
