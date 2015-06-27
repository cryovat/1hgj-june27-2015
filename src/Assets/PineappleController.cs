using UnityEngine;
using System.Collections;

public class PineappleController : MonoBehaviour
{	
	// Update is called once per frame
	void Update () {
        transform.Translate(Time.smoothDeltaTime * -3, 0, 0);
	}

    public void OnBecameInvisible()
    {
        Debug.Log("Bye!");

        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var bat = collision.gameObject.GetComponent<BatController>();

        if (bat != null)
        {
            bat.life = Mathf.Min(BatController.OriginalLife, bat.life + 3);
            Destroy(gameObject);
        }
    }
}
