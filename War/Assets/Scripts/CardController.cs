using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class CardController : MonoBehaviour {
  public Sprite backSprite;

  private Sprite selfSprite;
  private bool isVisible;
  private int worth;

	void Start() {
    selfSprite = GetComponent<SpriteRenderer>().sprite;

    StartCoroutine(SetVisible(false, false));
    Regex regex = new Regex(@"\d+");
    Match match = regex.Match(gameObject.name);
    worth = int.Parse(match.Value);
	}
	
  public void OnMouseUp() {
    if (!isVisible) {
      StartCoroutine(GameController.S.OnFlip(this));
    }
  }

  public IEnumerator SetVisible(bool isVisible, bool animate = true) {
    this.isVisible = isVisible;
/*
    if (animate) {
      float degrees = 180.0f;
      int n = 20;
      float delta = degrees / n;

      for (int i = 0; i < n / 2; ++i) {
        transform.Rotate(Vector3.up, delta);
        yield return new WaitForSeconds(0.01f);
      }

      transform.Rotate(Vector3.up, -180.0f);
      GetComponent<SpriteRenderer>().sprite = isVisible ? selfSprite : backSprite;

      for (int i = n / 2 + 1; i < n; ++i) {
        transform.Rotate(Vector3.up, delta);
        yield return new WaitForSeconds(0.01f);
      }

      transform.rotation = Quaternion.identity;

    } else {*/
      GetComponent<SpriteRenderer>().sprite = isVisible ? selfSprite : backSprite;
    //}
		yield return new WaitForSeconds (1);
  }

  public int GetWorth() {
    return worth;
  }
}
