# Forum8

# Code Implemenation
The code is implemented in .Net 6 using C# which is a Console App.
We can run this solution by building it in Visual Studio 2019 or by installing the .Net 6 version if not already present.
In case if visual studio 2019 is not present we can run the code from "cmd" using below commands.
  - Building the solution by using the following command :-
     - dotnet build
      ![image](https://github.com/hpissei/Forum8/assets/32298685/7580a573-1b10-41c2-89a3-e7ac09a2c129)
     - cd Forum8
     - dotnet run
      ![image](https://github.com/hpissei/Forum8/assets/32298685/c606ec3c-8550-4a9b-a05e-3f7484ab45e7)
      ![image](https://github.com/hpissei/Forum8/assets/32298685/005caa8f-c58f-4abf-9fb5-f0fde369bdd7)
 - I have uploaded a private fiddle also which we can check online without need to install anything. Link:-https://dotnetfiddle.net/8kpJtB
      ![image](https://github.com/hpissei/Forum8/assets/32298685/f1fd9b7b-d390-48ea-b149-00531b2699f6)

 - Input :-
    - Enter the array size ( Number of integers the array can have. ) Ex. 4
    - Enter the arrray elements separated by space. Ex. 1 3 4 0
    - Enter the target value. Ex.  4

 - Output :-
   - Array of unique pairs meeting the target sum. Ex. [(0,4),(1,3)]
     
 - Screenshot :-
    ![image](https://github.com/hpissei/Forum8/assets/32298685/54aef7ee-24f0-407e-ae62-2fcdcf011927)

# 2. An explanation of your algorithm choice
  - I have programmed the solution using custom algorithm for sorting the array I have used Insertion Sort.
  - I have sorted the array initially.
  - Then tried to see if the sum of array element is equal to target value then I have added it to the dictionary if already not present.
  - Finally once I get the pairs I have used StringBuilder to build a string for output which I am displaying on the console.
    
# 3. Time and space complexity.

| Algorithm      | Time Complexity | Space Complexity |
|--------------- | --------------- | ---------------- |
| Insertion Sort |  O(N^2)         |	O(1)            |
| Unique Pairs   |  O(N^2)	       |  O(1)            |




  
