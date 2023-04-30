using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDistance
{
    class DocDistance
    {
        // *****************************************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // *****************************************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>
        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {

            string doc1 = File.ReadAllText(doc1FilePath);
            string doc2 = File.ReadAllText(doc2FilePath);
            doc1.ToLower();
            doc2.ToLower();
            string Str1="";
            string Str2="";
            Dictionary<string, double> myst1 = new Dictionary<string, double>();
            Dictionary<string, double> myst2 = new Dictionary<string, double>();
            for (int i = 0; i < doc1.Length; i++)
            {
                if (char.IsDigit(doc1[i]) || char.IsLetter(doc1[i]))  
                {
                    Str1+= doc1[i]; 
                    Str1=Str1.ToLower();    
                }
                else 
                {
                    if(Str1.Length > 0)
                    {
                        if (myst1.ContainsKey(Str1))
                        {
                            myst1[Str1]++;
                        }
                        else
                        {
                            myst1[Str1] = 1;

                        }
                        Str1 = "";
                    }
                    
                }
            }
            if (Str1.Length>0)
            {
                if (myst1.ContainsKey(Str1))
                {
                    myst1[Str1]++;
                }
                else 
                {
                    myst1[Str1] = 1;
                }

            }
            for (int i = 0; i < doc2.Length; i++)
            {
                if ((char.IsDigit(doc2[i]) || char.IsLetter(doc2[i])) )  
                {
                    Str2 += doc2[i];
                    Str2 = Str2.ToLower();  

                }
                else
                {
                    if (Str2.Length > 0)
                    {
                        if (myst2.ContainsKey(Str2))
                        {
                            myst2[Str2]++;
                        }
                        else
                        {
                            myst2[Str2] = 1;
                        }
                        Str2 = "";
                    }
                 
                }
            }
            if (Str2.Length > 0)
            {
                if (myst2.ContainsKey(Str2))
                {
                    myst2[Str2]++;
                }
                else
                {
                    myst2[Str2]= 1;
                }
            }  
            double D1D2 = 0,D1=0,D2=0;
            foreach (var word in myst1.Keys)
            {
                if (myst2.ContainsKey(word))
                D1D2 += (myst1[word] * myst2[word]);
            }
            foreach (var word in myst1.Keys)
            {
                D1 += Math.Pow(myst1[word], 2);    
            }
            foreach (var word in myst2.Keys)
            {
                D2 += Math.Pow(myst2[word], 2);
            }
            double sqrt=Math.Sqrt(D1*D2);
            double dist = Math.Acos(D1D2/sqrt)*180/Math.PI;


            return dist;

            // TODO comment the following line THEN fill your code here
            // throw new NotImplementedException ();
        }
    }
}
