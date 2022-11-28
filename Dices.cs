using System;
using System.Collections.Generic;

namespace Dices
{
    public class Dice
    {
        /// <summary>
        /// List of each single dice throw value
        /// </summary>
        private List<int>? _throwsOutputList;

        #region Public methods

        /// <summary>
        /// Returns total result dices output + modifier
        /// </summary>
        /// <param name="dices"></param>
        /// <param name="diceTypes"></param>
        /// <param name="modifier"></param>
        /// <returns></returns>
        public int ThrowDices(int dices = 1, DiceType diceTypes = DiceType.d100, int modifier = 0)
        {
            CalculateThrows(dices, diceTypes, modifier, out int total);
            
            return total + modifier;
        }

        /// <summary>
        /// Returns list of every single dice throw from previous use of ThrowDices method
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<int> GetThrowsOutputList()
        {
            if (_throwsOutputList != null)
                return _throwsOutputList;
            else
                throw new Exception(message: "List is null, use ThrowDices method first.");
        }

        #endregion

        #region Private methods

        private int CalculateThrows(int dices, DiceType diceTypes, int modifier, out int result)
        {
            _throwsOutputList = new List<int>();
            Random res = new Random();
            var value = 0;
            var total = 0;

            for (int i = 0; i < dices; i++)
            {
                switch (diceTypes)
                {
                    case DiceType.d4:
                        value = res.Next(1, 5);
                        break;
                    case DiceType.d6:
                        value = res.Next(1, 7);
                        break;
                    case DiceType.d8:
                        value = res.Next(1, 9);
                        break;
                    case DiceType.d10:
                        value = res.Next(1, 11);
                        break;
                    case DiceType.d12:
                        value = res.Next(1, 13);
                        break;
                    case DiceType.d20:
                        value = res.Next(1, 21);
                        break;
                    case DiceType.d100:
                        value = res.Next(1, 101);
                        break;
                }

                total += value;
                _throwsOutputList.Add(value);
            }

            result = total;

            return result;
        }

        #endregion
    }
}
