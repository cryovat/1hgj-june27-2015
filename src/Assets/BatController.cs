using UnityEngine;
using System.Collections;
using System.Threading;

public class BatController : MonoBehaviour
{
    public const float OriginalLife = 5f;

    private SpriteRenderer _renderer;
    private float _counter;
    private Sprite _currentSprite;
    private Sprite _swapSprite;
    
    public Sprite altSprite;
    public int score = 0;
    public float life = OriginalLife;

	// Use this for initialization
	void Start ()
	{
	    _renderer = gameObject.GetComponent<SpriteRenderer>();
	    _currentSprite = _renderer.sprite;
	    _swapSprite = altSprite;
	    score = 0;
	    life = OriginalLife;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var delta = Time.smoothDeltaTime;

	    _counter += delta;
	    life -= delta;

	    var c = _renderer.color;
	    _renderer.color = new Color(c.r, c.g, c.b, 1f * (life / OriginalLife));

	    if (life <= 0)
	    {
	        Destroy(gameObject);
	    }

	    if (_counter > 0.2)
	    {
	        var temp = _renderer.sprite;
	        _renderer.sprite = _swapSprite;
	        _swapSprite = temp;
	        _counter = 0;
	    }

	    if (Input.GetKey(KeyCode.UpArrow))
	    {
	        gameObject.transform.Translate(0, delta * 5, 0);
	    }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(0, delta * -5, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(delta * -5, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(delta * 5, 0, 0);
        }

	}
}
