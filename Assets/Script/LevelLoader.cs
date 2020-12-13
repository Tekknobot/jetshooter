using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBar;
    public GameObject stageTrigger;
    public GameObject bossBar;

    public GameObject loading;
    public GameObject stageClear;
    public GameObject gameOver;

    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && SceneManager.GetActiveScene().buildIndex == 0) {
            loading.SetActive(true);
            StartCoroutine(LoadLevel(1));
        }

        if (player.GetComponent<playerTarget>().currentHealth <= 0) {
            playerBar.SetActive(false);
            bossBar.SetActive(false);
            gameOver.SetActive(true);
            StartCoroutine(LoadLevel(0));
        }

        if (stageTrigger == null) {
            playerBar.SetActive(false);
            bossBar.SetActive(false);
            stageClear.SetActive(true);
            StartCoroutine(LoadLevel(1));
            //LoadNextLevel();
        }        
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
