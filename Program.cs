//*****************************************************************************
//* 350. Intersection of Two Arrays II leetcode                              **
//* I used two hash tables to find common numbers then built the return table**
//* from those hash tables                             -Dan                  **
//*****************************************************************************


/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* intersect(int* nums1, int nums1Size, int* nums2, int nums2Size, int* returnSize) {
    int* retNum = (int*)malloc(sizeof(int) * (nums1Size < nums2Size ? nums1Size : nums2Size));
    int hash1[100001] = {0};
    int hash2[100001] = {0};
    int maxNum = 0;
    int minNum = 100000;
    int count = 0;
    for(int i = 0; i < nums1Size; i++) 
    {
        hash1[nums1[i]]++;
        if (maxNum < nums1[i]) maxNum = nums1[i];
        if (minNum > nums1[i]) minNum = nums1[i];
    }
    for(int i = 0; i < nums2Size; i++)
    {
        hash2[nums2[i]]++;
        if (maxNum < nums2[i]) maxNum = nums2[i];
        if (minNum > nums2[i]) minNum = nums2[i];
    }
    for(int i = minNum; i <= maxNum; i++)
    {
//        printf("Hash1[%d] = %d and Hash2[%d] = %d\n",i,hash1[i],i,hash2[i]);
        if ((hash1[i] > 0) && (hash2[i] > 0))
        {
//            printf("Match\n");
            while((hash1[i] > 0) && (hash2[i] > 0))
            {
                retNum[count] = i;
                count++;
                hash1[i]--;
                hash2[i]--;
            }
//            printf("return[%d] = %d\n",count-1,retNum[count-1]);
        }
    }
    *returnSize = count;
    return retNum;
}