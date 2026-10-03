public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length == 0){
            return "";
        } else {

            string result = "";

            string shortestWord = strs[0];

            for (int i = 0; i < strs.Length; i++){
                if (strs[i].Length < shortestWord.Length){
                    shortestWord = strs[i];
                }
            }

            for (int i = 0; i < shortestWord.Length; i++){
                for (int j = 0; j < strs.Length; j++){
                    if (strs[j][i] != strs[0][i]){
                        return result;
                    }
                }
                result += strs[0][i];
            }

            return result;
        }
    }
}