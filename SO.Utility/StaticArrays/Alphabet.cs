using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SO.Utility
{
    public class Alphabet
    {

        public static List<string> getAlphabet(){
            string[] list = ("A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z").Split(',');
            return list.ToList();
        }


    }
}
