using System;
using System.Collections.Generic;
using GeneratorPortableLibrary.DTO;

namespace GeneratorPortableLibrary
{
    public class GenerateRandomNumber
    {

        protected  List<PowerBall> ListGenerated { get;private set;}
        public GenerateRandomNumber()
        {
            ListGenerated = new List<PowerBall>();
        }
        

        public List<PowerBall> GenerateList(int count)
        {
            for(int i=0;i<count;i++)
            {
                ListGenerated.Add(generateNumber());
            }
            return ListGenerated;
        }

        private int numberToGenerate(List<int> listgenerated)
        {
            var date = DateTime.Now.ToString("yyMMddHHmm");
            var seed = Convert.ToInt32(date);
            var rand = new Random(seed);
            var number = rand.Next(1, 69);
            for(int i=0;i<listgenerated.Count;i++)
            {
                if(listgenerated[i]==number)
                {
                    i--;
                    date = DateTime.Now.ToString("yyMMddHHmm");
                    seed = Convert.ToInt32(date);
                    rand = new Random(seed);
                    number = rand.Next(1, 69);
                }
            }            
            listgenerated.Add(number);
            return number;
        }
        private int generatePowerNumber()
        {
            var date = DateTime.Now.ToString("yyMMddHHmm");
            var seed = Convert.ToInt32(date);
            Random rand = new Random(seed);
            var number = rand.Next(1, 26);
            return number;
        }

        private PowerBall generateNumber()
        {
            List<int> local = new List<int>(5);
            var PowerBallObject = new PowerBall();
            PowerBallObject.FirstNumber = numberToGenerate(local);
            PowerBallObject.SecondNumber = numberToGenerate(local);
            PowerBallObject.ThirdNumber = numberToGenerate(local);
            PowerBallObject.FourthNumber = numberToGenerate(local);
            PowerBallObject.FifthNumber = numberToGenerate(local);
            PowerBallObject.PowerNumber = generatePowerNumber();
            return PowerBallObject;
        }
    }
}
