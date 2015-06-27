using UnityEngine;
using System.Collections;

public class ConductorComponent : MonoBehaviour
{
    public const float DefaultCooldown = 0.7f;
    private float _modifier = 1;

    public GameObject bomb;
    public GameObject pineapple;

    private float _coolDown = DefaultCooldown;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (GameObject.Find("Bat") == null) Destroy(gameObject);

	    _modifier = Mathf.Max(0.1f, _modifier - Time.smoothDeltaTime/100f);

        if (_coolDown > 0)
	    {
            _coolDown -= Time.smoothDeltaTime;
	    }
	    else
	    {
	        var good = Random.Range(0, 2) == 0;

	        Instantiate(good ? pineapple : bomb, new Vector3(8, Random.Range(-3f, 3f)), Quaternion.identity);

            _coolDown = Random.Range(DefaultCooldown * _modifier, DefaultCooldown * _modifier * 2);
	    }
	}
}
