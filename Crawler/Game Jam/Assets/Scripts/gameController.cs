using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
    public GameObject longSprite;
    public GameObject shortSprite;
    public AudioClip shortBeep;
    public AudioClip longBeep;
    private AudioSource audio;
    private ArrayList morseCode;
    private ArrayList playerCode;
    private bool notPlayed = true;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        morseCode = new ArrayList();
        playerCode = new ArrayList();
        for (int i = 0; i < 3; i++)
        {
            addBeep();
        }

	}

    // Update is called once per frame
    void Update() {
        if (notPlayed)
        {
            StartCoroutine(playMorseCode());
            notPlayed = false;
        }
        if (Input.GetButtonDown("short"))
        {
            audio.PlayOneShot(shortBeep);
            playerCode.Add(shortBeep);
            longSprite.GetComponent<SpriteRenderer>().enabled = false;
            shortSprite.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetButtonDown("long"))
        {
            audio.PlayOneShot(longBeep);
            playerCode.Add(longBeep);
            shortSprite.GetComponent<SpriteRenderer>().enabled = false;
            longSprite.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(playerCode.Count == morseCode.Count)
        {
            shortSprite.GetComponent<SpriteRenderer>().enabled = false;
            longSprite.GetComponent<SpriteRenderer>().enabled = false;
            for (int i = 0; i < playerCode.Count; i++)
            {
                if(playerCode[i] != morseCode[i])
                {
                    endGame();
                }
            }
            playerCode.Clear();
            addBeep();
            notPlayed = true;
            System.Threading.Thread.Sleep(1000);
        }
	}

    private IEnumerator playMorseCode()
    {
        for (int i = 0; i < morseCode.Count; i++)
        {
            bool shortClip = ((AudioClip)morseCode[i]).length == shortBeep.length;
            setSpriteVisible(shortClip, true);
           
            audio.PlayOneShot((AudioClip) morseCode[i]);
            yield return new WaitForSeconds(((AudioClip)morseCode[i]).length + 0.25f);

            setSpriteVisible(shortClip, false);
        }
        clearSprites();
    }

    void clearSprites()
    {
        longSprite.GetComponent<SpriteRenderer>().enabled = false;
        shortSprite.GetComponent<SpriteRenderer>().enabled = false;
    }
    void setSpriteVisible(bool shortClip, bool enabled)
    {
        if (shortClip)
        {
            longSprite.GetComponent<SpriteRenderer>().enabled = !enabled;
            shortSprite.GetComponent<SpriteRenderer>().enabled = enabled;
        }
        else
        {
            shortSprite.GetComponent<SpriteRenderer>().enabled = !enabled;
            longSprite.GetComponent<SpriteRenderer>().enabled = enabled;
        }
    }

    void endGame()
    {
        Application.LoadLevel("game");
    }

    void addBeep()
    {
        if (Random.Range(-1.0f, 1.0f) >= 0)
        {
            morseCode.Add(shortBeep);
        }
        else
        {
            morseCode.Add(longBeep);
        }
    }
}
