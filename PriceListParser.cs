using System.Collections.Generic;

namespace price
{
    /// <summary>
    /// ingoing price list file parser
    /// </summary>
    class PriceListParser
    {
        /// <summary>
        /// Detect if passed string matches to Price Position String
        /// </summary>
        /// <param name="s">any string</param>
        /// <returns>true if passed string matches to Price Position String</returns>
        private static bool DetectPricePosition(string s)
        {
            //result detector
            int i;
            try
            {
                //try convert to int price position index
                i = int.Parse(s.Substring(5, 6));
            }
            //if error occurs assign 0 to detector
            catch (System.ArgumentOutOfRangeException)
            {
                i = 0;
            }
            catch (System.FormatException)
            {
                i = 0;
            }
            //if detector is more than 0 then index has been found
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// parse Price Position String to array of substrings
        /// </summary>
        /// <param name="s">Price Position String</param>
        /// <returns>array of substrings (N п/п, Номер, НАИМЕНОВАНИЕ ПРОДУКЦИИ, 
        /// Ед. изм., Обьем изделия, ОТПУСКНАЯ ЦЕНА, Отпускная цена без НДС)</returns>
        private static string[] ParsePrice(string s)
        {
            string[] price = {
                s.Substring(0, 4).Trim(), //N п/п
                s.Substring(5, 6).Trim(), //Номер
                s.Substring(12, 31).Trim(), //НАИМЕНОВАНИЕ ПРОДУКЦИИ
                s.Substring(42, 9).Trim(), //Ед. изм.
                s.Substring(50, 9).Trim(), //Обьем изделия
                s.Substring(59, 13).Trim(), //ОТПУСКНАЯ ЦЕНА
                s.Substring(72, 13).Trim() //Отпускная цена без НДС
                //.Replace('.', ',')
            };
            return price;
        }

        /// <summary>
        /// parse array of price list strings
        /// </summary>
        /// <param name="lines">array of price list strings</param>
        /// <returns>array of price positions [N п/п, Номер, НАИМЕНОВАНИЕ ПРОДУКЦИИ, 
        /// Ед. изм., Обьем изделия, ОТПУСКНАЯ ЦЕНА, Отпускная цена без НДС]</returns>
        public static List<string[]> ParseLines (string[] lines)
        {
            //result array of price positions
            List<string[]> prices = new List<string[]>();
            //save line number (in result array) if price position name takes more than one line
            int currentLine = -1;
            foreach (string line in lines)
            {
                if (DetectPricePosition(line))
                {
                    //if line is price positions
                    prices.Add(ParsePrice(line));
                    //save line number (in result array) to current line
                    currentLine++;
                }
                //if line includes only "НАИМЕНОВАНИЕ ПРОДУКЦИИ" 
                //then this is second line of previous position
                else if (line.Length == 42)
                {
                    prices[currentLine][2] += (' ' + line.Trim());
                }
            }
            return prices;
        }
    }
}
