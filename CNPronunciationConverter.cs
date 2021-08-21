using System;
using System.Collections.Generic;
using Microsoft.International.Converters.PinYinConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamNMSL.yndcksh
{
    /// <summary>
    /// 首字母轉中文類
    /// </summary>
    public class CNPronunciationConverter
    {
        
        static List<string> UsefulCNWords = init();

       

        List<string> WordLibrary=new List<string>();
        private static List<string> init()
        {
            string json = System.Text.Encoding.UTF8.GetString(Resources.CNWORDS_FILE);
            JArray WordJsonArray = (JArray)JsonConvert.DeserializeObject(json);
            List<string> r = new List<string>();
            foreach (var item in WordJsonArray)
            {
                r.Add(item.ToString());
            }
            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomWordLibraryJSONArray">JsonArray形式的詞庫</param>
        public CNPronunciationConverter(string CustomWordLibraryJSONArray)
        {
            try
            {
                JArray WordJsonArray=(JArray)JsonConvert.DeserializeObject(CustomWordLibraryJSONArray);
                foreach (var item in WordJsonArray)
                {
                    WordLibrary.Add(item.ToString());
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private string GetPronunciation(string ChineseWord) {
            string GetString(char cn_char){
               
                    string rr = "";
                if (ChineseChar.IsValidChar(cn_char))
                {
                    var a = new ChineseChar(cn_char).Pinyins;
                    foreach (var item in a)
                    {
                        rr += item;
                    }
                    return rr + " ";
                }
                else
                {
                    return cn_char.ToString().ToUpper();
                }
                    
            }
            string ResultString = "";
            char[] ChineseChars=ChineseWord.ToCharArray();
            foreach (var cn_char in ChineseChars)
            {
                
                if (true)
                {
                    
                    ResultString += GetString(cn_char);
                }
                else
                {
                    throw new Exception("Is not a legal Chinese character");
                }
            }
            return ResultString.TrimEnd();
        }
        private string GetPinyinAbbreviation(string ChinesePinyin) {
            string ResultString = "";
            foreach (var pinyin in ChinesePinyin.Split(" "))
            {
               
                if (true)
                {
                    ResultString += pinyin.ToCharArray()[0];
                }
                else
                {
                    throw new Exception("Is not a legal Chinese Pinyin");
                }
               
            }
            return ResultString;

        }
        /// <summary>
        /// 將首字母轉換成你詞庫裏對應的中文字詞，如果詞庫内不包含這個字詞，會從默認的詞庫内匹配，若未匹配到，將返回大寫后的原文
        /// </summary>
        /// <param name="Abbreviation">拼音縮寫</param>
        /// <returns></returns>
        public string GetTextFromAbbreviation(string Abbreviation) {
            
            foreach (var Word in WordLibrary)
            {
                if (GetPinyinAbbreviation(GetPronunciation(Word)).ToLower()==Abbreviation.ToLower())
                {
                    return Word;
                }
            }
            foreach (var Word in UsefulCNWords)
            {
                if (GetPinyinAbbreviation(GetPronunciation(Word)).ToLower() == Abbreviation.ToLower())
                {
                    return Word;
                }
            }

            return Abbreviation.ToUpper();
        }
       
    }
}
