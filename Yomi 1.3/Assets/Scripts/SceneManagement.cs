using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {
    public int numCena;

    public void OnClick() {
        SceneManager.LoadScene(numCena);
    }
}
