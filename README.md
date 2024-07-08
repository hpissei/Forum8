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
	- I am iterating through the array elements ( Now I am using only one for loop. )
	- For each element I now calculating the difference i.e. target - array element value.
	- If the difference is less then the array element value then I am skipping the iteration.
	- If difference is equal to array element value need to check if the element appears more then once then only add to the dictionary if the key not already present in dictionary.
	- Else If the difference is present as an element in array then I am inserting the pair ( array element, difference ) to the dictionary if the key not already present in dictionary.
	- After all items are inserted I am printing the pairs to console.

# 3. Time and space complexity.

| Algorithm      | Time Complexity | Space Complexity |
|--------------- | --------------- | ---------------- |
| Unique Pairs   |  O(N)	   |  O(n)            |




  
