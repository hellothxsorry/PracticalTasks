# Practical Task 9
"Unit test frameworks" module:

Modify the application from the first task of the Basic of .NET framework and C # by separating the functionality of counting the maximum number of unequal consecutive characters in a string into a separate method. Extend functionality by adding two more methods:
- determining the maximum number of consecutive identical letters of the Latin alphabet in a line
- determining the maximum number of consecutive identical digits

For each method, write Unit Tests (use the NUnit, XUnit or MSTest framework is your choice; follow AAA and FIRST). When creating tests, pay special attention to equivalence classes.

![image](https://user-images.githubusercontent.com/50228202/212547577-0ec9d0c9-d653-4453-992f-497d78aa844f.png)

![image](https://user-images.githubusercontent.com/50228202/212548533-87086726-3d51-43e7-b8ec-8b92cf1bc1b5.png)

Equivalence classes for "Maximum unequal consecutive characters" tests:
- Class "Lower case letters"
- Class "Whitespace"
- Class "Digits"
- Class "Upper case letters"
- Class "Combination of lower case and upper case letters"
- Class "Special characters"
- Class "Empty string"

![image](https://user-images.githubusercontent.com/50228202/212548805-f0c40123-65e7-4e97-90b1-e2c1f428c261.png)

Equivalence classes for "Maximum unequal consecutive characters" tests:
- Class "Mix of digits and lower case letters"
- Class "Lower case latin letters"
- Class "Combination of lower case and upper case"
- Class "Whitespace"
- Class "Lower case letters separated by space"
- Class "Empty string"
- Class "Special characters"

![image](https://user-images.githubusercontent.com/50228202/212548560-2cd98201-1ca6-4ef4-aeac-203b22cf6527.png)

Equivalence classes for "Maximum unequal consecutive characters" tests:
- Class "Mix of letters and digits"
- Class "Mix of upper case and lower case letters"
- Class "Empty string"
- Class "Unique digits"
- Class "Whitespace"
- Class "Digits + special characters"
