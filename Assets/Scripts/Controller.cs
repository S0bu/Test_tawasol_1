using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    //[SerializeField] private GameObject eachPlayerInstance;
    //[SerializeField] private Transform ground;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator Loading()
    {
        var operation = SceneManager.LoadSceneAsync(sceneBuildIndex: 1, LoadSceneMode.Additive);

        while(!operation.isDone) { yield return null; }

        var scene = SceneManager.GetSceneByBuildIndex(1);
        if (scene.isLoaded)
        {
            new WaitForSeconds(2);
            SceneManager.UnloadSceneAsync(sceneBuildIndex: 0);
            InstantiateWorld();
        }
    }

    private void InstantiateWorld()
    { 
        GameObject clone = PhotonNetwork.Instantiate("Each Player Instance", new Vector3(Random.Range(0f, 10f), 1.1f, Random.Range(0f, 10f)), Quaternion.identity);
        clone.name = "Player";
    }
}
