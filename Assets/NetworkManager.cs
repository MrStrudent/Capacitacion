using System;
using System.Collections;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string userName, string email, string pass, Action<Response> response)
    {
        StartCoroutine(CO_CreateUser(userName, email, pass, response));
    }
    private IEnumerator CO_CreateUser(string userName, string email, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", userName);
        form.AddField("email", email);
        form.AddField("password", pass);

        WWW w = new WWW("http://localhost/Capacitacion/createUser.php");
        yield return w;
        response(JsonUtility.FromJson<Response>(w.text));
    }
}
[Serializable]
public class Response
{
    public bool done = false;
    public string message = "Error usuario ya existente";
}
