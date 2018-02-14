using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SATSolver
{
    
    class Program
    {
        public struct clausula {

               public  List<int> elementos;
            public clausula (int x)
            {
                elementos = new List<int>();
            }

        }
       
        static void Main(string[] args)
        {
            
            List<clausula> clausulas = new List<clausula>();
            List<clausula> c_unitarias = new List<clausula>();
            int [] i = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            clausula clau = new clausula(1);
            Console.WriteLine("Clauses");
            for (int w = 0; w < i.Length; w++)
            {
               
                if (!i[w].Equals(0))
                {
                     clau.elementos.Add(i[w]);
                    Console.Write(i[w] + "//");
                }
                else
                {
                    Console.WriteLine();
                    clausulas.Add(clau);
                    clau = new clausula(1);
                }
            }
            
            
            foreach (clausula c in clausulas)
            {
                if (c.elementos.Count.Equals(1))
                {
                    c_unitarias.Add(c);
                }
            }

            
            List<clausula> clausulas2 = clausulas;
            foreach (clausula c in c_unitarias)
            {
                for (int u=0;u<clausulas.Count;u++)
                {
                    if (clausulas.ElementAt(u).elementos.Contains(c.elementos.ElementAt(0)))
                    {
                        clausulas2.Remove(clausulas.ElementAt(u));
                    }
                   
                }
            }

            Console.WriteLine("Clauses remainning after removing the unitary clause");
            foreach (clausula c in clausulas)
            {
                for (int z=0;z<c.elementos.Count;z++)
                {
                    Console.Write(c.elementos.ElementAt(z) + "/");
                }

                Console.WriteLine();
            }

            for(int d=0; d<clausulas.Count;d++)
            {
                
                int pure = clausulas.ElementAt(d).elementos.ElementAt(d);
                Boolean aparece = false;
                  foreach (clausula k in clausulas)
                    {
                        if (k.elementos.Contains(-pure))
                        {
                            aparece = true;
                        }
                    }
                if (aparece.Equals(false))
                {
                    Console.WriteLine("Removing clauses that contains " + pure);
                    for (int u = 0; u < clausulas.Count; u++)
                    {
                        if (clausulas.ElementAt(u).elementos.Contains(pure))
                        {
                            clausulas2.Remove(clausulas.ElementAt(u));
                        }

                    }

                    foreach (clausula c in clausulas)
                    {
                        Console.WriteLine("Remainning clauses");
                        for (int z = 0; z < c.elementos.Count; z++)
                        {
                            Console.Write(c.elementos.ElementAt(z) + "/");
                        }

                        Console.WriteLine();
                    }
                }

                
               
                d++;
            }


            if (clausulas.Count().Equals(0))
            {
                Console.WriteLine("Solved!!");
            }
            else {
                List<clausula> clausulas3 = clausulas;
                while (clausulas.Count !=0) { 
                    
                        for (int u = 0; u < clausulas.Count; u++)
                        {
                            int remove = clausulas.ElementAt(u).elementos.ElementAt(0);
                            Console.WriteLine("Separating clauses with " + remove + " or " + -remove);
                            if (clausulas.ElementAt(u).elementos.Contains(remove))
                            {
                                clausulas3.ElementAt(u).elementos.Remove(remove);
                            }
                            if (clausulas.ElementAt(u).elementos.Contains(-remove))
                            {
                                clausulas3.ElementAt(u).elementos.Remove(-remove);

                            }
                            if (clausulas.ElementAt(u).elementos.Count.Equals(0))
                            {
                                clausulas3.Remove(clausulas.ElementAt(u));
                            }

                        foreach (clausula c in clausulas)
                        {
                            Console.WriteLine("Remainning clauses");
                            for (int z = 0; z < c.elementos.Count; z++)
                            {
                                Console.Write(c.elementos.ElementAt(z) + "/");
                            }

                            Console.WriteLine();
                        }
                    }

                    
                }
            }




            if (clausulas.Count().Equals(0))
                {
                    Console.WriteLine("Solved!!");
                }
                else
                {
                    Console.WriteLine("Can't be solved!!");
                foreach (clausula c in clausulas)
                {
                    Console.WriteLine("Remainning clauses"+clausulas.Count);
                    for (int z = 0; z < c.elementos.Count; z++)
                    {
                        Console.Write(c.elementos.ElementAt(z) + "/");
                    }

                    Console.WriteLine();
                }
            }
            Console.ReadKey();
                   
                }

            

           
        }
    }

