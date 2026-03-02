using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [SerializeField]                    // to add the field in unity
    private string _horizontalAxis = "Horizontal", _verticalAxis = "Vertical";
   
    [SerializeField]
    private Rigidbody2D _rb2d;
   
    [SerializeField]
    private float _speed = 3f;
   
    private Vector2 _input;  
    public UnityEvent OnPlayerDie;   

    void FixedUpdate()
    {
        _rb2d.linearVelocity= _input*_speed;    //it called every fixed framerate frame, if MonoBehavior is enabled
    }


    // Update is called once per frame
    void Update()
    {
     float horizontalInput = Input.GetAxisRaw(_horizontalAxis); //included in Unity moving left right
     float verticalInput = Input.GetAxisRaw(_verticalAxis); //included in Unity moving up and down
     _input = new Vector2(horizontalInput, verticalInput);
     _input.Normalize();                                // to not higher diagonal speed
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(OnPlayerDie != null)
        {
            OnPlayerDie.Invoke();
        }
        Destroy(gameObject);
    }
}
