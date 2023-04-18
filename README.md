# AI Studio
> AI Studio helps you with the power of chatGPT in many subjects such as adding unit tests, refactoring code, adding summary, etc. while writing code, just by right click on the code.

![image](https://user-images.githubusercontent.com/4971326/232881049-73adc4ff-c863-43c3-b6c7-172352fe2216.png)

- First you need to create an API key from the https://platform.openai.com/account/api-keys
- Go to **Tools/Options/AI Studio** page and write the key in General section

![image](https://user-images.githubusercontent.com/4971326/232878716-92165bd8-f1b9-4b3e-ba59-237e1bfad1bc.png)

- If you prefer refactoring the page after the change, keep **Format Document** as True.

### Code It:
Write a use case where you want to write the code, select the statement, right click, and click "AI Studio / **Code It**".

![image](https://user-images.githubusercontent.com/4971326/232882864-85547d6f-75ee-4d49-8684-a3b736b5da2e.png)

Prints the result after a short time:

![image](https://user-images.githubusercontent.com/4971326/232883443-de21b5c2-3415-4f5b-bed9-49077bf7732c.png)

### Add Comments:
Select the lines of code you want to comment, right click, and click "AI Studio / **Add Comments**".

Returns the selected code with detailed comments.

![image](https://user-images.githubusercontent.com/4971326/232887104-8778b163-6cbf-4dcb-a12b-caa6ba266565.png)

### Refactor:
Select all method, right click, and click "AI Studio / **Refactor**".

The refactored result:

![image](https://user-images.githubusercontent.com/4971326/232884573-c8f18fc5-3564-4d8d-ad3a-742b85142b36.png)

### Add Summary:
Select the all method or just the first line of the method, right click, and click "AI Studio / **Add Summary**".

Gives a very detailed and logical result:

![image](https://user-images.githubusercontent.com/4971326/232885737-84f7befa-1cad-4ff7-ba10-4b84f659b2fc.png)

### Explain:
Select the lines of code you want to explain, right click, and click "AI Studio / **Explain**".

Shows a popup that includes explanations of the selected code:

![image](https://user-images.githubusercontent.com/4971326/232888457-c12651dd-abcf-48f1-a0a5-578aaacfff06.png)

#### Customizable Commands
- AI studio is a flexible tool that allows you to customize the all commands. Go to *Tools/Options/AI Studioo/Commands*,
- Write something to help chatGPT about the behaviors of the commands.

![image](https://user-images.githubusercontent.com/4971326/232889800-d62af5ec-8c41-4fa2-a81e-a6ee84bdf61a.png)

Then trigger the command again, and you will see the results affected by your comments:

![image](https://user-images.githubusercontent.com/4971326/232890352-64908383-623b-43f7-8dfa-32f305f67a43.png)

### Add Unit Tests:
Select the whole method, right click, and click "AI Studio / **Add Unit Tests**".

Prints the unit test(s) based on your choices:

![image](https://user-images.githubusercontent.com/4971326/232892126-91f3c335-3633-4b4f-8c27-2da5b404e329.png)

You can also customize the unit tests on *Tools/Options/AI Studio/Unit Test*

![image](https://user-images.githubusercontent.com/4971326/232892595-9e304843-8b0d-4420-b058-a0f44688f46e.png)

- **Unit Testing Framework:** Select unit testing framewok to setup main functionalities.
  - MSTest
  - xUnit
  - NUnit
- **Isolation Framework:** An isolation framework is a set of programmable APIs that makes creating fake objects much simpler, faster, and shorter than hand-coding them.
  - None
  - Moq
  - FakeItEasy
  - NSubstitute
- **Test/Dummy Data Framework:** Test Data Builders and Dummy Data Generators.
  - None
  - AutoFixture
  - Bogus
  - GenFu
  - NBuilder
  - AutoBogus
- **Fluent Assertions Framework:** Fluent assertions frameworks is a set of .NET extension methods that allow you to more naturally specify the expected outcome of a TDD or BDD-style unit test.
  - None
  - FluentAssertions
  - Shouldly
  - NFluent
- **Customize:** Add any other details to customize unit tests.
