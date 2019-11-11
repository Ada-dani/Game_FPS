using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseArm : MonoBehaviour {

    public GameObject Arm1;
    public GameObject Arm2;
    public int NrArm = 1;
    public AudioClip SwitchArm;

    // Use this for initialization
    void Start()
    {
        Arm1.SetActive(true);
        Arm2.SetActive(false);


    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NrArm = 1;
            //Arm2.GetComponent<Animator>().SetTrigger("Descent");
            StartCoroutine(Pause());

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            NrArm = 2;
            //Arm1.GetComponent<Animator>().SetTrigger("Descent");
            StartCoroutine(Pause());
        }

    }

    IEnumerator Pause()
    {
        GetComponent<AudioSource>().PlayOneShot(SwitchArm);

        if (NrArm == 2)
        {
            yield return new WaitForSeconds(0.5f);
            Arm1.SetActive(false);//deactivate arm1
            Arm2.SetActive(true);//active arm2
            Arm2.GetComponent<Animator>().SetTrigger("PlayerIdle");//animation playeridle

        }

        if (NrArm == 1)
        {
            yield return new WaitForSeconds(0.5f);
            Arm2.SetActive(false);//deactivate arm2
            Arm1.SetActive(true);//active arm1
            Arm1.GetComponent<Animator>().SetTrigger("PlayerIdle");//animation playeridle

        }
    }
}
