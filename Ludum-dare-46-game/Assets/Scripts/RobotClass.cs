using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RobotClass : MonoBehaviour
{

    public float battery_left = 100;
    public float battery_max = 150;

    public float decharge_rate = 2.0f;
    public float charge_rate = 10.0f;
    bool has_item = false;
    bool is_charging = false;

	
    public float turnSpeed = 3.0f;
    public float moveSpeed = 18.0f;

    public GameObject allBeacons;

    public Text chargeText;

    void Update()
    {
        MouseAiming();

        if(!is_charging)
            battery_left -= decharge_rate * Time.deltaTime;

        chargeText.text = "Charge left: " + Mathf.Round(battery_left).ToString();
    }

    private void FixedUpdate()
    {
        KeyboardMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MedKit" && !has_item)
        {

            Destroy(other.gameObject);
            has_item = true;
            int childCount = allBeacons.transform.childCount;
            allBeacons.transform.GetChild(Random.Range(0, childCount - 1)).gameObject.SetActive(true);

            //Add text...
        }
        if(other.gameObject.tag == "DeliveryBeacon" && has_item)
        {
            Destroy(other.gameObject);
            has_item = false;
            //Add text...
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ChargingStation" && battery_left < battery_max)
        {
            is_charging = true;
            battery_left += charge_rate * Time.deltaTime;
        }
        is_charging = false;
    }

    void MouseAiming()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
    }

    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        dir.z = Input.GetAxis("Vertical");

        if(battery_left > 0.0f)
            transform.Translate(dir * moveSpeed * Time.deltaTime);
            
    }
}
