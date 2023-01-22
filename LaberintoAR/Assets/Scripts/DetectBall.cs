using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectBall : MonoBehaviour
{
    /*
    * Script que tiene tanto la meta como la llave, comprobamos que tipo de objeto es
    * y dependiendo si es meta o llave, realizamos una accion o otra:
    * Si es meta saldra la pantalla de victoria
    * Si es una llave abrira una puerta automaticamente que le pasamos mediante script
    */
    [SerializeField] private bool isGoal;
    [SerializeField] private AudioManager AM;
    

    [Header("Goal")]
    private bool goalReached = false;
    [SerializeField] private GameObject txtCongratulations, confetti;
    [SerializeField] private PointsManager txtPoints;
    [SerializeField] private float points;

    [Header ("Key")]
    [SerializeField] private GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isGoal && !goalReached)
        {
            goalReached = true;
            StartCoroutine(showText());
            txtPoints.addPoints(points);
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            other.gameObject.GetComponent<Collider>().enabled = false;
            Instantiate(confetti, other.transform);
        }
        else if(!isGoal)
        {
            AM.keySound();
            Destroy(door.gameObject);
            Destroy(this.gameObject);
        }
    }

    /*
    * Empezamos una couritna para mostrar el texto y el confeti al llegar a la meta 
    */
    private IEnumerator showText()
    {
        txtCongratulations.SetActive(true);
        txtCongratulations.GetComponent<Animator>().SetTrigger("textAnimation");
        AM.goalSound();
        yield return new WaitForSeconds(2f);
        txtCongratulations.SetActive(false);
    }
}
