public class Solution {
    public int RomanToInt(string s) {

        /*
        For each character:

            Am I at the last index?
                → add the current value

            Otherwise:
                compare current value to next value

                current >= next
                    → add current

                current < next
                    → subtract current
        */

        Dictionary<char, int> RomanNumeralValues = new Dictionary<char, int>();

        RomanNumeralValues.Add('I',1);
        RomanNumeralValues.Add('V',5);
        RomanNumeralValues.Add('X',10);
        RomanNumeralValues.Add('L',50);
        RomanNumeralValues.Add('C',100);
        RomanNumeralValues.Add('D',500);
        RomanNumeralValues.Add('M',1000);

        int number = 0;

        for (int i = 0; i < s.Length; i++){

            if (s.Length - 1 == i){

                number += RomanNumeralValues[s[i]];

            } else {
                if (RomanNumeralValues[s[i]] >= RomanNumeralValues[s[i + 1]]){
                    number += RomanNumeralValues[s[i]];
                } else {
                    number -= RomanNumeralValues[s[i]];
                }
            }
        }

        return number;

    }
}