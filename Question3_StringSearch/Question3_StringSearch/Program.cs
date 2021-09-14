using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace Question3_StringSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing
            string filename = "J:\\SoftwareProjects\\Q2_PrecisionLender_Assignment\\testing_files";
            string sString = "s";
            string dFile = "J:\\SoftwareProjects\\Q2_PrecisionLender_Assignment\\result.txt";
            FileProcessor(filename, sString, dFile);
            //testing ends

            Console.ReadKey();

        }

        
        ///<summary>Method traverses a directory and search for a string within each file.
        ///Result is written to the filename specify.</summary>
         
        private static void FileProcessor(string dPath, string searchString, string filename)
        {
            var allFiles = Directory.GetFiles(dPath, "*.*", SearchOption.AllDirectories);

            int numOccurances = 0, numFiles = 0, numLines = 0;

            //accessing each file in parallel
            Parallel.ForEach(allFiles, (f) =>
            {
                numFiles++; //important to put this here
                var lines  = File.ReadLines(f);
                
                //searching line by line
                foreach (string line in lines)
                {
                    //check the number of time the search string appears in 
                    // the line
                    int count = Regex.Matches(line, searchString).Count;
                 
                    if (count > 0) {

                        numLines++;
                        numOccurances += count;

                        File.AppendAllText(filename, line + "\n");

                    }
                }
          
            });


            Console.WriteLine("Number of files processed : " + numFiles);
            Console.WriteLine("Number of lines search text was found in: " + numLines );
            Console.WriteLine("Total number of occurances of the search text processed : " + numOccurances);
        }

        
    }
}
