using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.smoothDeltaTime * -4, 0, 0);
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
            Destroy(bat.gameObject);
            Destroy(gameObject);
        }
    }
}
