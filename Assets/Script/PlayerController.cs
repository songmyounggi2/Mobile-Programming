using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Vector3 movement;
    GameObject[] monsters;

    private GameObject nearMonster;
    private GameObject postNearMonster;

    void Start()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster");
    }

    void Update()
    {
        calculateMovement();
        findNearMonster();
        changeMonsterColor();
    }

    void findNearMonster()
    {
        float minDistance = Mathf.Infinity;
        postNearMonster = nearMonster;

        for (int idx = 0; idx < monsters.Length; idx++)
        {
            float distance = (transform.position - monsters[idx].transform.position).sqrMagnitude;

            if (minDistance > distance)
            {
                minDistance = distance;
                nearMonster = monsters[idx];
            }
        }

        Debug.Log(nearMonster.name);
    }

    void changeMonsterColor()
    {
        if (postNearMonster != null)
        {
            postNearMonster.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
        }

        nearMonster.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);
    }

    void calculateMovement()
    {
        movement.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.position = transform.position + (movement * moveSpeed);
    }
}
