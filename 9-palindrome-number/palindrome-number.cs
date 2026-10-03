public class Solution {
    public bool IsPalindrome(int x) {
        
        //x_string
        string og = x.ToString();

        char[] charArray = og.ToCharArray();

        Array.Reverse(charArray);

        string y = new string(charArray);

        return og == y;

        
    }
}