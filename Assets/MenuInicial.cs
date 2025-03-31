using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class MenuInicial : MonoBehaviour
{
    public void Empezar(string SeleccionNivel){
SceneManager.LoadScene(SeleccionNivel);
    }
    public void Salir(){
    Application.Quit();
    Debug.Log("Saliendo . . . ");
    }
}
