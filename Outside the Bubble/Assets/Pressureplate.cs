using UnityEngine;



public class PressurePlate : MonoBehaviour

{

    private Vector3 _originalPos;

    public bool _isPressed;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _maxDownDistance = 0.1f;

    [SerializeField] private GameObject targetObject;

    [SerializeField] private PressurePlateDuoLeft otherPressurePlate;

    




    void Start()

    {

        _originalPos = transform.position;

        _spriteRenderer = GetComponent<SpriteRenderer>();


    }



    private void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player"))
        {

            _isPressed = true;

            _spriteRenderer.color = Color.green;


            if (targetObject != null)
            {
                if (otherPressurePlate._isPressed2 == true)
                {
                    targetObject.SetActive(false);
                }
            }
        }
        else if (other.CompareTag("Platform"))
        {
            _isPressed = true;

            _spriteRenderer.color = Color.green;

            if (targetObject != null)
            {
                if(otherPressurePlate._isPressed2 == true)
                {
                    targetObject.SetActive(false);
                }
            }
        }
        else if(otherPressurePlate._isPressed2 == true)
        {
            targetObject.SetActive(false);
        }


    }



    private void OnTriggerExit2D(Collider2D other)

    {

        if (other.CompareTag("Player"))

        {

            _isPressed = false;

            _spriteRenderer.color = Color.red;

        }
        else if (other.CompareTag("Platform"))
        {
            _isPressed = false;

            _spriteRenderer.color = Color.red;
        }

    }





    void FixedUpdate()

    {

        if (_isPressed && transform.position.y > _originalPos.y - _maxDownDistance)

        {

            transform.Translate(0f, -0.01f, 0f);

        }

        else if (!_isPressed && transform.position.y < _originalPos.y)

        {

            transform.Translate(0f, 0.01f, 0f);

        }

    }

}