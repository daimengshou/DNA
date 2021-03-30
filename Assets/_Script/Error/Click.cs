using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    public GameObject A_L;
    public GameObject T_L;
    public GameObject C_L;
    public GameObject G_L;

    // Use this for initialization
  public  void Create_A()
    {
        GameObject.Instantiate(A_L);
    }
  public   void Create_T()
    {
        GameObject.Instantiate(T_L);
    }
   public  void Create_C()
    {
        GameObject.Instantiate(C_L);
    }
  public  void Create_G()
    {
        GameObject.Instantiate(G_L);
    }
}
