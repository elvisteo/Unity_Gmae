using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour
{
    // Start is called before the first frame update
    public Text pointsText;
    public void Congrat(int score) {
       gameObject.SetActive(true);
       pointsText.text = "Score: " + score.ToString();
    }

   public void RestartButton()
   {
       SceneManager.LoadScene("SampleScene");
   }
}
