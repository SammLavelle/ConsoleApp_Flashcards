using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Flashcards.models
{
    internal class Card
    {
        public int Id { get; set; }
        public string CardFront { get; set; }
        public string CardBack { get; set; }
        public int? NumberOfTimesSeen { get; set; }
        public int? NumberOfTimesCorrect { get; set; }
        public int StackID { get; set; }
    }
}
