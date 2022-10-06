using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cambiarScena : MonoBehaviour
{

    public int numeroEscena;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            SceneManager.LoadScene(numeroEscena);
        }
    }
 
}
