using UnityEngine;

public class BouncyJiggle : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    //public Collider2D Collider2D;

    //Store initial scale
    private Vector3 initialScale;
    public Vector3 PlayField;
    
    public bool isPlaced = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        CardPlaced();

    }

    private void OnMouseOver()
    {
        CardPlaced();

        //When mouse is over, make card jiggle

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos);

        if (hit != null && hit.gameObject == gameObject)
        {
            float rotation = 1f * Mathf.Sin(Time.time * speed);
            rb.MoveRotation(rotation);
        }

    }

    private void OnMouseEnter()
    {
        CardPlaced();
        IncreaseScale(true);
    }

    private void OnMouseExit()
    {
        CardPlaced();
        IncreaseScale(false);
    }


    private void Awake()
    {
        initialScale = transform.localScale;
    }

    //Increase Scale Method
    private void IncreaseScale(bool status)
    {
        Vector3 finalScale = initialScale;
        //If status is true, increase scale
        if (status)
        {
            finalScale = initialScale * 1.1f;
        }
        transform.localScale = finalScale;

    }

    void OnMouseDown()
    {
        // When mouse is clicked, move card to playing field
        isPlaced = true;
        transform.position = PlayField;
    }

    // Placing a card when there is already a card should be placed to the side
    // UNFINISHED ///////////////////////////////////////////////////////////////////////////
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlaced && other.CompareTag("Card"))
        {
            transform.position = new Vector3(PlayField.x + 100f, PlayField.y, PlayField.z);
        }
    }

    // UNFINISHED ///////////////////////////////////////////////////////////////////////////
    void CardPlaced()
    {
        // Logic for when a card is placed in the play field
        if (transform.position == PlayField)
        {
            return; // Do not jiggle if in play field
        }
    }

}
