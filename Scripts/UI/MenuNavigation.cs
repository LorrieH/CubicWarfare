using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuNavigation : MonoBehaviour
{
	void Update()
    {
        if (SceneManager.GetActiveScene().name == SceneNames.MENUSCENE)
        {
            if (Input.GetButtonDown("Xbox_Button_Start_1"))
            {
                SceneManager.LoadScene(SceneNames.CHARACTERSELECTIONSCENE);
            }

            if (Input.GetButtonDown("Xbox_Button_B_1"))
            {
                Application.Quit();
            }
            if (Input.GetButtonDown("Xbox_Button_Y_1"))
            {
                SceneManager.LoadScene(SceneNames.INSTRUCTIONSSCENE);
            }
        }
        
        else if(SceneManager.GetActiveScene().name == SceneNames.INSTRUCTIONSSCENE)
        {
            if (Input.GetButtonDown("Xbox_Button_B_1"))
            {
                SceneManager.LoadScene(SceneNames.MENUSCENE);
            }
        }
    }
}