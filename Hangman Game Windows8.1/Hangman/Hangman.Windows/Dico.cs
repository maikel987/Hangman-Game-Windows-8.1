using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Dico
    {
        public string word;

        public Dico(bool easy = true)
        {
            Random ran = new Random();
            if (easy)
            {
                word = easyDico[ran.Next(easyDico.Length - 1)];
            }
            else
            {
                word = hardDico[ran.Next(hardDico.Length - 1)];
            }
        }

       private static string[] easyDico = { "bad", "big", "but", "cat", "cow", "did", "fat", "for",
            "has", "his", "law", "lay", "low", "new", "not", "oil", "old", "our", "red",
            "sad", "she", "sir", "toy", "war", "yes", "yet", "you", "also", "best", "bird",
            "blue", "book", "both", "done", "door", "duck", "easy", "fact", "flag", "flat",
            "from", "goat", "good", "high", "hole", "hope", "idea", "inch", "joke", "king",
            "lamp", "lazy", "life", "long", "luck", "male", "mine", "more", "most", "much",
            "must", "nice", "note", "odor", "only", "ours", "part", "poor", "rock", "rope",
            "rule", "same", "slow", "some", "tail", "tall", "tape", "test", "than", "that",
            "them", "then", "they", "thin", "this", "tiny", "told", "tree", "ugly", "very",
            "wall", "weak", "well", "wide", "with", "your" };

       private static string[] hardDico = { "again", "angry", "badly", "black", "brown", "clean", "could",
            "dirty", "dream", "empty", "every", "found", "funny", "grass", "green", "happy",
            "heavy", "her's", "horse", "light", "light", "match", "maybe", "metal", "might",
            "never", "noisy", "other", "paper", "place", "plant", "quick", "quiet", "round",
            "score", "short", "skirt", "small", "smart", "sorry", "so-so", "their", "these",
            "thick", "thing", "those", "trash", "truth", "voice", "vowel", "wheel", "white",
            "whose", "woman", "worse", "worst", "worst", "wrong", "young", "yours", "almost",
            "always", "animal", "beside", "better", "chance", "common", "custom", "enough",
            "excuse", "future", "little", "little", "matter", "normal", "orange", "pencil",
            "person", "pretty", "really", "simple", "slower", "slowly", "strong", "stupid",
            "theirs", "useful", "window", "yellow", "already", "alright", "another", "because",
            "correct", "disturb", "example", "garbage", "herself", "himself", "history", "holiday",
            "nothing", "pattern", "perhaps", "quickly", "someone", "student", "thought", "without",
            "actually", "anything", "beginner", "complete", "electric", "notebook", "ordinary",
            "original", "pleasant", "possible", "possibly", "probably", "sentence", "shoulder",
            "triangle", "yourself", "carefully", "certainly", "dangerous", "different",
            "difficult", "excellent", "extremely", "important", "necessary", "newspaper",
            "ourselves", "something", "definitely", "everything", "impossible", "impressive",
            "photograph", "themselves", "yourselves", "electricity", "embarrassed" };
    
       public static string NewWord(bool easy = true)
        {
            Random ran = new Random();
            if (easy)
            {
                return easyDico[ran.Next(easyDico.Length - 1)];
            }
            else
            {
                return hardDico[ran.Next(hardDico.Length - 1)];
            }
        }

         public static bool IsGood(string word, char answer)
        {
            return (word.IndexOf(answer) != -1);
        }

        public bool IsGood(char answer)
        {
            return (word.IndexOf(answer) != -1);
        }


    }
}
