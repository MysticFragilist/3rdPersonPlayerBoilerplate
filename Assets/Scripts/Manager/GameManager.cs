using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Manager;
using Assets.Scripts.SaveSystem;
using Cinemachine;
using Grid = Assets.Scripts.Manager.Grid;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player")]
    public GameObject PlayerPrefab;
    public GameObject PlayerInstantiate;
    
    [Header("Camera")] 
    public Camera ThirdPersonCamera;
    public CinemachineFreeLook CinemachineFreeLook;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
        {
            Debug.LogWarning($"Instance already exists, destroying object!");
            Destroy(this);
        }

        var asyncOp = SceneManager.LoadSceneAsync((int) SceneIndexes.TestDebug, LoadSceneMode.Additive);
        asyncOp.completed += LoadingHasComplete;
    }

    private void LoadingHasComplete(AsyncOperation op)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int) SceneIndexes.TestDebug));
        Debug.Log("Game scene has finished loading");
        ThirdPersonCamera = Camera.main;
        CinemachineFreeLook = FindObjectOfType<CinemachineFreeLook>();

        PlayerData dataToLoad;
        try
        {
            dataToLoad = SaveSystem.LoadPlayer();
        }
        catch (SaveSystem.NoSaveFileException e)
        {
            dataToLoad = CreateNewGameEnvironment();
        }

        SpawnPlayer(dataToLoad);
    }

    private void SpawnPlayer(PlayerData data)
    {
        var pos = data.GetPosition() + (Vector3.up * 2);
        var rot = data.GetRotation();

        PlayerInstantiate = Instantiate(PlayerPrefab, pos, rot);
        CharacterController charCont = PlayerInstantiate.GetComponent<CharacterController>();
        Grid.InputManager.PlayerMovement = charCont;
        CinemachineFreeLook.Follow = PlayerInstantiate.transform;
        CinemachineFreeLook.LookAt = PlayerInstantiate.transform;
    }

    private PlayerData CreateNewGameEnvironment()
    {
        // TODO: here add logic for which a new game will start

        return new PlayerData(Vector3.zero, Quaternion.identity);
    }

    #region ApplicationBehavior
    void OnApplicationQuit()
    {
        var player = PlayerInstantiate.GetComponent<Player>();
        SaveSystem.SavePlayer(player);
    }
    #endregion
}
