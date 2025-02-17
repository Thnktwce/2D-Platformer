using UnityEngine;
using System.Collections;

public class PlatformPlayer : MonoBehaviour
{
    public float speed = 250.0f;
    private Rigidbody2D _body;
    private Animator _anim;
    public float jumpforce = 12.0f;
    


    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.linearVelocity.y);
        _body.linearVelocity = movement;
        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX,0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
        _body.linearVelocity = movement;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _body.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }
    
}