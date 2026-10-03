class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        unordered_map<int, int> seenNumbers;
        for (int i = 0; i < nums.size(); i++){
            int complement = target - nums[i];
            if (seenNumbers.find(complement) != seenNumbers.end()) {
                return {seenNumbers[complement], i};
            }
            seenNumbers[nums[i]] = i;
        }

        return{};
    }
};