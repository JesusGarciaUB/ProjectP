using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicPlayer : MonoBehaviour
{
    private PlayerBase self;
    private Vector3 parkingPosition = new Vector3(-0.379f, 0, 0);
    //parking
    public bool Parking = false;
    private bool DoingParking = false;
    //leaving port
    public bool LeavingPort = false;
    private bool DoingLeavingPort = false;

    private void Awake()
    {
        self = GetComponent<PlayerBase>();
        LeavingPort = true;
    }
    private void Update()
    {
        if (Parking) Park();
        if (LeavingPort) LeavePort();

        if (DoingParking) DoingPark();
        if (DoingLeavingPort) DoingLeavePort();
    }

    private void Park()
    {
        Parking = false;
        DoingParking = true;
        self.canHit = false;
        self.canMove = false;
    }

    private void DoingPark()
    {
        Vector3.Lerp(transform.position, parkingPosition, self.speed * Time.deltaTime);
        if (transform.position == parkingPosition)
        {
            DoingParking = false;
        }
    }

    private void LeavePort()
    {
        LeavingPort = false;
        DoingLeavingPort = true;
        self.canHit = false;
        self.canMove = false;
    }

    private void DoingLeavePort()
    {
        Vector3.Lerp(transform.position, new Vector3(0, 0, 0), self.speed * Time.deltaTime);
        if (transform.position == new Vector3(0,0,0)) {
            DoingLeavingPort = false;
            self.canHit = true;
            self.canMove = true;
        }
    }
}
