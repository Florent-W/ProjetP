using System;

namespace ClassLibrary1
{
    public class Personnage
    {
        private string m_nom;
        private int m_age;

        public Personnage(string nom, int age)
        {
            this.m_nom = nom;
            this.m_age = age;
        }
    }
}
