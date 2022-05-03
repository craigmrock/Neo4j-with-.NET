using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neo4j.Driver;

namespace Neo4J_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = GraphDatabase.Driver("neo4j+s://6b5ad.prod-orch-0068.neo4j.io:7687", AuthTokens.Basic("neo4j", "art-la-ten-ex-ski-9235")))
            using (var session = driver.Session())
            {

                var result = session.Run("MATCH(m:Mode) RETURN m.name AS name, m.formula AS formula");
                
                foreach (var record in result)
                {
                    Console.WriteLine($"{record["name"].As<string>()},{record["formula"].As<string>()}");
                }


            }
            Console.ReadLine();
        }
    }
}

