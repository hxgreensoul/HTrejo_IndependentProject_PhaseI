using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text sheepText;

    private Rigidbody rb;
    public int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        sheepText.text = ""; //adds text for sheep 
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            SetCountText();
        }

        //Checks if player enters sheepZone1 to display text
        if (other.gameObject.CompareTag("sheepZone1"))
        {
            Debug.Log("I am a Navajo Churro sheep");
            sheepText.text = "I am a Navajo-Churro sheep and am threatened to be endangered." + "\n" + "My fleece has three types of fiber including an undercoat, guard hairs, and kemp.";
        }
        //Checks if player enters sheepZone2 to display text
        if (other.gameObject.CompareTag("sheepZone2"))
        {
            Debug.Log("I am a Hog Island sheep");
            sheepText.text = "I am a Hog Island rare sheep and am critically endangered." + "\n" + "My wool is a medium quality and can be beige, gray, or black.";
        }
        //Checks if player enters sheepZone3 to display text
        if (other.gameObject.CompareTag("sheepZone3"))
        {
            Debug.Log("I am a Romeldale-CVM sheep");
            sheepText.text = "I am a Romeldale-CVM sheep and am threatened to be endangered." + "\n" + "My wool is fine and soft with several natural color variations.";
        }
        //Checks if player enters sheepZone4 to display text
        if (other.gameObject.CompareTag("sheepZone4"))
        {
            Debug.Log("I am a Cotswold sheep");
            sheepText.text = "I am a Cotswold sheep and am threatened to be endangered." + "\n" + "My wool is long, lustrous, and comes in gray, white, and black.";
        }
        //Checks if player enters sheepZone5 to display text
        if (other.gameObject.CompareTag("sheepZone5"))
        {
            Debug.Log("I am a Jacob sheep");
            sheepText.text = "I am a Jacob sheep and am threatened to be endangered." + "\n" + "My wool is multicolored with white and spots of black and brown.";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sheepZone1"))
        {
            Debug.Log("I left the Navajo-Churro sheep");
            sheepText.text = "";
        }
        if (other.gameObject.CompareTag("sheepZone2"))
        {
            Debug.Log("I left the Hog Island sheep");
            sheepText.text = "";
        }
        if (other.gameObject.CompareTag("sheepZone3"))
        {
            Debug.Log("I left the Romeldale-CVM sheep");
            sheepText.text = "";
        }
        if (other.gameObject.CompareTag("sheepZone4"))
        {
            Debug.Log("I left the Cotswold sheep");
            sheepText.text = "";
        }
        if (other.gameObject.CompareTag("sheepZone5"))
        {
            Debug.Log("I left the Jacob sheep");
            sheepText.text = "";
        }
    }

void SetCountText()
    {
        countText.text = "Your Score: " + count.ToString();
        if (count >= 25)
        {
            winText.text = "You visited 5 rare sheep! Let's get to the finish zone!";
        }
    }
}