using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBar;
    public GameObject bossTrigger;
    public GameObject bossBar;

    public GameObject loading;

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
            StartCoroutine(LoadLevel(1));
        }

        if (bossTrigger == null) {
            playerBar.SetActive(false);
            bossBar.SetActive(false);
            //LoadNextLevel();
            StartCoroutine(LoadLevel(0));
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
