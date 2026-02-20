# Lecture Evaluation API

This project is a .NET 10 Web API built with ASP.NET Core, following the Onion Architecture principles to ensure a modular, maintainable, and scalable design. It utilizes 
Entity Framework Core (EF Core) for data access and integrates with a MySQL database for persistence.

## Goal 

The objective is to build an API that captures lecture evaluations of students. For lectures the system should allow CRUD* operations. A lecture has some meta information 
like lecture title, lecturer name and external id. Evaluations are anonymous, always related to a specific lecture and consist of a text for improvement suggestions and a 
text for positive feedback (no additional meta information). For evaluations the system should support CRD*.

Bonus: The system should offer a functionality to summarise all evaluations of a lecture by using an external generative AI service (like Gemini). The AI summary should 
be added to the lecture alongside the other meta information.

