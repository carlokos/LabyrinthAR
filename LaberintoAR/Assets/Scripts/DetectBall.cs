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

    [Header ("Goal")]
    [SerializeField] private GameObject txtCongratulations, confetti;
    [SerializeField] private AudioSource congratsSound;

    [Header ("Key")]
    [SerializeField] private GameObject door;
    [SerializeField] private AudioSource keyObtenined;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isGoal)
        {
            StartCoroutine(showText());
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            other.gameObject.GetComponent<Collider>().enabled = false;
        }
        else if(!isGoal)
        {
            Destroy(door.gameObject);
            Destroy(this.gameObject);
            keyObtenined.Play();
        }
    }

    /*
    * Empezamos una couritna para mostrar el texto y el confeti al llegar a la meta 
    */
    private IEnumerator showText()
    {
        txtCongratulations.SetActive(true);
        txtCongratulations.GetComponent<Animator>().SetTrigger("textAnimation");
        confetti.SetActive(true);
        congratsSound.Play();
        yield return new WaitForSeconds(2f);
        confetti.SetActive(false);
        txtCongratulations.SetActive(false);
    }
}
