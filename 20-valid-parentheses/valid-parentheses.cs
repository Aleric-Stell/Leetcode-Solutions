public class Solution {
    public bool IsValid(string s) {

        /*

        Set Key->Value relationship between open and closed brackets
        Use a stack to add valid characters to the stack and remove them when a closed bracket's key matches the character in the top of the stack.

        For each character:

            If it's an opening bracket:
                put it on the stack

            If it's a closing bracket:
                if the stack is empty:
                    return false

                check the opening bracket at the top

                if it doesn't match:
                    return false

                if it does match:
                    remove that opening bracket

        After processing every character:

            if the stack is empty:
                return true

        */

        // create dictionary
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>();
        bracketPairs.Add(')', '(');
        bracketPairs.Add('}', '{');
        bracketPairs.Add(']', '[');

        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++){
            if (s[i] == '(' || s[i] == '{' || s[i] == '['){
                stack.Push(s[i]);
            } else {
                if(stack.Count == 0){
                    return false;
                }

                if (stack.Peek() != bracketPairs[s[i]]){
                    return false;
                } else {
                    stack.Pop();
                }
            }
        }

        if (stack.Count == 0){
            return true;
        } else {
            return false;
        }
    }
}