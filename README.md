# Asp.net Rest API with MongoDB
 This is a Basic Rest API I made with Asp.Net that connects to my MongoDB account. It was made with c# in vs code.

Here's all of the resources I used to help me create this project.

Creating the API in vscode on Mac:
https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-8.0&tabs=visual-studio-code
https://youtu.be/jJK9alBkzU0?si=VsLTgD_2UZ3wlkgY
***One massive part both of these tutorials left out is that you HAVE to put this function `app.MapControllers();` in your main `program.cs` before you call 'app.Run();', otherwise none of the endpoints you set up will be connected to your app. I think the `dotnet` commands for creating the project should have automatically done this since none of the tutorials addressed it. But it didn't happen for me so I got stuck for a long time.***

Creating Unit Tests for the API:
https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-8.0&WT.mc_id=beginwebapis-c9-cephilli
https://fakeiteasy.github.io/docs/8.0.0/
https://youtu.be/RgoytbbYbr8?si=mALu5k_Q5RqY1fQk
https://youtu.be/04nzwCE_nw0?si=xbuf_4TEsT8WIvQu
***Make sure to look at the FakeItEasy documentation for testing and faking async functions, these tutorials will give you the basic setup, but you'll need to tweak is for async use***

