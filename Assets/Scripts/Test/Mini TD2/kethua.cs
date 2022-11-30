using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kethua : MonoBehaviour
{
    // Start is called before the first frame update
    class Animal
    {
        protected double Weight;
        protected double Height;
        protected static int Legs;
        public Animal(double w, double h, int l)
        {
            Weight = w;
            Height = h;
            Legs = l;
        }
        public void Info()
        {
            
        }
            
    }


    class Cat : Animal
    {
       
        public Cat(double w, double h, int l) : base(w, h, l)
        {


        }
    }
    public void swap<T>(ref T a,ref T b)
    {
        T x = a;
        a = b;
        b = x;
    }
    private void Start()
    {
        int a = 1;
        int b = 5;
        swap(ref a,ref b);
        Debug.Log(a + "     " + b);
        string str1 = "nam";
        string str2 = "vu";
        swap(ref str1, ref str2);
        Debug.Log(str1 + "     " + str2);

    }
}
