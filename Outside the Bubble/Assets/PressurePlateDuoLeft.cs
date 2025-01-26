using UnityEngine;

public class PressurePlateDuoLeft : MonoBehaviour
{

    private Vector3 _originalPos;

    public bool _isPressed2;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _maxDownDistance = 0.1f;






    void Start()

    {

        _originalPos = transform.position;

        _spriteRenderer = GetComponent<SpriteRenderer>();

    }



    private void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player" ))

        {

            _isPressed2 = true;

            _spriteRenderer.color = Color.green;

        }
        else if (other.CompareTag("Platform"))
        {
            _isPressed2 = true;

            _spriteRenderer.color = Color.green;
        }

    }



    private void OnTriggerExit2D(Collider2D other)

    {

        if (other.CompareTag("Player"))

        {

            _isPressed2 = false;

            _spriteRenderer.color = Color.red;

        }
        else if (other.CompareTag("Platform"))
        {
            _isPressed2 = false;

            _spriteRenderer.color = Color.red;
        }

    }

    void FixedUpdate()

    {

        if (_isPressed2 && transform.position.y > _originalPos.y - _maxDownDistance)

        {

            transform.Translate(0f, -0.01f, 0f);

        }

        else if (!_isPressed2 && transform.position.y < _originalPos.y)

        {

            transform.Translate(0f, 0.01f, 0f);

        }

    }
}
