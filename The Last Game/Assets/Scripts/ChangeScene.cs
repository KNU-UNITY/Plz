using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameManager gm;

    void Awake()
    {
        gm = GetComponent<GameManager>();
    }

    public void ChangeScenebtn()
    {
<<<<<<< HEAD
        // if(this.gameObject.name=="Continue")
        //     gm.GameReset();
        
        // SceneManager.LoadScene("SampleScene");
=======
        if(this.gameObject.name=="Continue")
            gm.GameReset();
        
        SceneManager.LoadScene("SampleScene");
>>>>>>> parent of b518b49 (scripts move)
    }
}
