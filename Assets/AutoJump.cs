using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AutoJump : Agent
{
  //  [SerializeField] private Transform nearestCheckpoint;
  //  [SerializeField] private Transform nearestCheckpoint1;
    [SerializeField] private Transform Goal;
  //  [SerializeField] private Transform Floor;
    private Rigidbody2D rb;
    public float moveX;
    public int jump;
    private float noJump;
    private Vector2 startPos;
    private Vector2 goalPos;
    private Vector2 actualPos;
    private Vector2 actualgoalPos;
    //  private float nearestDistance = 0f;
    //  private int counter = 1;
    public bool FloorIsLava = false;

   // public GameObject[] AllCheckpoints;
    public jump Scr;

    public override void Initialize()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startPos = transform.localPosition;
        goalPos = Goal.transform.localPosition;

        // nearestDistance = Vector3.Distance(transform.position, AllCheckpoints[0].transform.position);
        /*
        for (int i = 0; i < AllCheckpoints.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, AllCheckpoints[i].transform.position);
            if (distance < nearestDistance)
                nearestCheckpoint = AllCheckpoints[i].transform;
        }

        nearestCheckpoint1 = AllCheckpoints[1].transform;
        */
    }
    public override void OnEpisodeBegin()
    {
        actualPos = startPos + new Vector2(Random.Range(-5f,5f), 0f);
        transform.localPosition = actualPos;
        rb.velocity = Vector2.zero;
        actualgoalPos = goalPos + new Vector2(Random.Range(-7f, 7f), Random.Range(-2f, 2f));
        Goal.transform.localPosition = actualgoalPos;
        noJump = 0f;
       
        /*
             for (int i = 0; i < AllCheckpoints.Length; i++)
                 AllCheckpoints[i].SetActive(true);
             if (counter > 3)
                 counter = counter - 3;
             else
                 counter = 1;
             nearestCheckpoint = AllCheckpoints[counter-1].transform;
             nearestCheckpoint1 = AllCheckpoints[counter].transform;
        */
        //  FloorIsLava = false;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation((Vector2)transform.localPosition);
        //sensor.AddObservation(transform.localPosition);
        // sensor.AddObservation((Vector2)nearestCheckpoint.position);
        sensor.AddObservation((Vector2)Goal.localPosition);
        //sensor.AddObservation(actualgoalPos);
        //  sensor.AddObservation((Vector2)nearestCheckpoint1.position);
        //  sensor.AddObservation((Vector2)Floor.position);
        sensor.AddObservation(rb.velocity);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        moveX = actions.ContinuousActions[0];
        jump = actions.DiscreteActions[0];

       // if (counter < 3)
       // Debug.Log(moveX);
       // Debug.Log(jump);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(5f);
            EndEpisode();
        }
   /*       
        if (other.TryGetComponent<Floor>(out Floor floor) && FloorIsLava == true)
        {
            SetReward(-100f);
            EndEpisode();
        }
   *//*
        if (other.TryGetComponent<Points>(out Points points))
        {

            if (other.gameObject.transform == nearestCheckpoint)
            {
                AddReward(1f);
                //other.gameObject.SetActive(false);
                if (counter < AllCheckpoints.Length)
                    counter++;
                nearestCheckpoint1 = AllCheckpoints[counter].transform;
                nearestCheckpoint = AllCheckpoints[counter - 1].transform;
            }
            /*
            else
            {
                AddReward(-1f);
               // EndEpisode();
            }
            */
        //}

        if (other.TryGetComponent<Bounds>(out Bounds bounds))
        {
            SetReward(-2f);
            EndEpisode();
        }
    }

    private void FixedUpdate()
    {
        if(jump == 0)
        {
            noJump++;
        }

        if(noJump == 100f) 
        {
            EndEpisode();
        }

       // AddReward(-1f / 5000f);

       float distance = Vector3.Distance(transform.localPosition, Goal.transform.localPosition);
       AddReward(-distance / 50000f);
    }


}
