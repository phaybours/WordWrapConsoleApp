# WordWrapConsoleApp

Problem statement / Feature
- Algorithm for text wrapping based on specified lenth per line
- Application should accept input from command line
- App should be able to sentence from text file and write result to another text file

Solution: Depending of user choice, the console applicaiton can read in input 
- Directly pasting the text to console 
- Reading line from text file (path to text file can be provide from the console)

if the user choose to enter input directory, the console displays a prompt for user to enter test to wrap and the length per line.
the solution then print out the result on the console.

if the user choose the option of reading input from text file, the console prompts the user to enter path to input text file, then path to the ouput text file and the length per line.
the result of the processing is stored in the output file.

If the inputted information is valid the values are passed to afuntion the attempts to read in the file apply the wrapping algorithm ( written as an extension method to string) and output the result in the specified output file.
