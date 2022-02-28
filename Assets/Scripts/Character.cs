using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float flyUp;
    [SerializeField] private LayerMask layerMask;

    Rigidbody2D rb2d;
    BoxCollider2D box2d;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy!");
            GameManager._intance.showGameOver();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && isGrounded())
        {
            rb2d.AddForce(new Vector2(0, flyUp), ForceMode2D.Impulse);
        }
    }
    private bool isGrounded()
    {
        float extra = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(box2d.bounds.center, Vector2.down, box2d.bounds.extents.y + extra, layerMask);

        Color rayColor;

        if (raycastHit.collider != null) rayColor = Color.green;
        else rayColor= Color.red;
        Debug.DrawRay(box2d.bounds.center, Vector2.down*(box2d.bounds.extents.y + extra) , rayColor);
        return raycastHit.collider != null;
    }
}
