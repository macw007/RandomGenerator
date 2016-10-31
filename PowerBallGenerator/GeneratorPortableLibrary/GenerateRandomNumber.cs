using System;
using System.Collections.Generic;
using GeneratorPortableLibrary.DTO;

namespace GeneratorPortableLibrary
{
    public class GenerateRandomNumber
    {

        protected  List<PowerBall> ListGenerated { get;private set;}
        private LinearRandomNumber seedGenerator;
        private List<int> fivenumbers;
        public GenerateRandomNumber()
        {
            ListGenerated = new List<PowerBall>();
            
        }
        

        public List<PowerBall> GenerateList(int count)
        {
            seedGenerator = new LinearRandomNumber(count);

            for(int i=0;i<count;i++)
            {
                ListGenerated.Add(generateNumber());
            }
            return ListGenerated;
        }

        private void numberToGenerate()
        {
            fivenumbers = new List<int>();
            var time = DateTime.Now.ToString("HHmmss");
            var seed = Convert.ToInt32(time);
            seedGenerator = new LinearRandomNumber(1233);
            var random = new Random(seedGenerator.Next(seed));
            var number = random.Next(1, 69);
            while(fivenumbers.Count<5)
            {
                if(doesNumberExist(number,fivenumbers))
                {
                     time = DateTime.Now.ToString("HHmmss");
                     seed = Convert.ToInt32(time);
                    var modular = seed % 30;
                    seedGenerator = new LinearRandomNumber(modular);
                     random = new Random(seedGenerator.Next(seed));
                     number = random.Next(1, 69);
                }
                else
                {
                    fivenumbers.Add(number);
                    number = random.Next(1, 69);
                }
            }
        }

        private bool doesNumberExist(int number,List<int> listgenerated)
        {
            for (int i = 0; i < listgenerated.Count; i++)
            {
                if (listgenerated[i] == number)
                {
                    return true;
                }
            }
                return false;
        }
        private int generatePowerNumber()
        {
            var date = DateTime.Now.ToString("yyMMddHHmm");
            var seed = Convert.ToInt32(date);
            Random rand = new Random(seedGenerator.Next(seed));
            var number = rand.Next(1, 26);
            return number;
        }

        private PowerBall generateNumber()
        {
            numberToGenerate();
            var PowerBallObject = new PowerBall();
            PowerBallObject.FirstNumber = fivenumbers[0];
            PowerBallObject.SecondNumber = fivenumbers[1];
            PowerBallObject.ThirdNumber = fivenumbers[2];
            PowerBallObject.FourthNumber = fivenumbers[3];
            PowerBallObject.FifthNumber = fivenumbers[4];
            PowerBallObject.PowerNumber = generatePowerNumber();
            return PowerBallObject;
        }
    }
}
