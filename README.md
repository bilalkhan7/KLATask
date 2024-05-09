# KLATask

This application is created for a coding assignment for Software Developer C#/.NET (gn) position at KLA, Dresden

Application Setup:

Clone the project in your desired directory.
Once cloned, open the solution file in Visual Studio and press on build solution. After build is successful press Start.
Navigate to the link where the angular application is running. By default it runs at `https://localhost:4200/`


Application Working:

Once the application is running on the web browser, enter an amount in the input field and press convert button. 
After submitting, an HTTP POST Request is sent from the client (Angular app) to the server (ASP.NET). 
The server then responds with the conversion of numbers and separators into words.
The result is then shown on the client UI.
For e.g. when the user enters 12,23 the result will be 12 dollars and 23 cents.
