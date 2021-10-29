using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeImage : MonoBehaviour {

    private Image _lives;
    public Image Lives
    {
        get{ return _lives; }
        set{ _lives = value; }
    }

	public void CutLives () {
        _lives.fillAmount -= 0.2f;
	}
}
