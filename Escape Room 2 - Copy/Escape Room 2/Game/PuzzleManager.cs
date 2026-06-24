using System.Collections.Generic;

namespace Escape_Room_2.Game
{
    /// <summary>
    /// מחלקה זו מנהלת את כל החידות במשחק.
    /// שומרת את רשימת החידות, עוקבת אחר החידה הנוכחית, בודקת תשובות של השחקנים 
    /// ומנהלת את מנגנון Hint-Reveal במהלך המשחק
    /// </summary>
    public class PuzzleManager
    {
        private List<Puzzle> puzzles;

        private int currentIndex = 0;
        public int WrongAnswers { get; private set; } = 0;
        public int RevealsUsed { get; private set; } = 0;

        /// <summary>
        /// יוצרת  PuzzleManagerחדש ואת רשימת החידות של המשחק
        /// </summary>
        public PuzzleManager()
        {
            puzzles = new List<Puzzle>
            {
                // Puzzle 1 - Mona Lisa
                new Puzzle(
                    question: "My creator is...",
                    questionLocation: "SCREEN",
                    answer: "Leonardo Da Vinci",
                    hintText: "A famous actor shares a name with this artist",
                    hintImage: "Images\\dicaprio.jpg",
                    type: "TEXT",
                    images: new List<string> { "Images\\monalisa.jpg" }
                ),

                // Puzzle 2 - Beethoven
                new Puzzle(
                    question: "I wrote many symphonies in the 18-19th century",
                    questionLocation: "SCREEN",
                    answer: "Beethoven",
                    hintText: "My name contains a kitchen appliance",
                    hintImage: "Images\\dogbeethoven.jpg",
                    type: "TEXT",
                    images: new List<string> { "Images\\ovenpartiture.jpg" }
                ),

                // Puzzle 3 - Venus Statue
                new Puzzle(
                    question: "In ancient times I rose at dawn and night, a wandering star that guided sailors right.",
                    questionLocation: "SCREEN",
                    answer: "Venus",
                    hintText: "Think of Sandro Botticelli's famous painting",
                    hintImage: "",
                    type: "CHOICE",
                    images: new List<string> { "Images\\statuevenus.jpg" },
                    choices: new List<string> { "Images\\venus.jpg", "Images\\mars.jpg", "Images\\saturn.jpg" }
                )
            };
        }

        /// <summary>
        /// מחזירה את החידה הנוכחית מסוג Puzzle בהתאם למיקום הנוכחי ברשימת החידות
        /// </summary>
        public Puzzle GetCurrentPuzzle()
        {
            return puzzles[currentIndex];
        }

        /// <summary>
        /// מקבלת תשובה שהוזנה על ידי השחקן
        ///בודקת האם התשובה שהתקבלה נכונה
        ///אם התשובה נכונה מוחזר הערך true 
        /// אם התשובה שגויה מוחזר הערך false
        /// ומספר הטעויות גדל באחד
        /// </summary>
        public bool CheckAnswer(string answer)
        {
            if (answer.ToLower().Trim() == puzzles[currentIndex].Answer.ToLower())
            { 
                return true;
            }
            WrongAnswers++;
            return false;
        }

        /// <summary>
        ///מעבירה את המשחק לחידה הבאה ברשימה
        ///אם קיים מעבר אפשרי מוחזר true
        /// ואם אין חידות נוספות מוחזר false
        /// </summary>
        public bool MoveNext()
        {
            if (currentIndex < puzzles.Count - 1)
            {
                currentIndex++;
                WrongAnswers = 0;
                return true;
            }
            return false; 
        }

        /// <summary>
        ///בודקת האם מספר הטעויות הגיע לערך המאפשר הצגת רמז
        ///ומחזירה true או false בהתאם
        /// </summary>
        public bool ShouldShowHint() => WrongAnswers == 3;

        /// <summary>
        ///בודקת האם מספר הטעויות הגיע לערך המאפשר הצגת כפתור Reveal 
        ///ומחזירה true או false בהתאם
        /// </summary>
        public bool ShouldShowReveal() => WrongAnswers == 6;

        /// <summary>
        ///מוסיפה 1 למספר הפעמים שהשחקנים חשפו תשובה. 
        /// </summary>
        public void UseReveal()
        {
            RevealsUsed++;
        }
    }
}
