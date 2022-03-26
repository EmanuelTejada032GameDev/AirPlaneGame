using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayBtn : MonoBehaviour
{

   public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
