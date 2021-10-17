# Library Project

Coding Sample based around a real-world Library; the books within it, and the words within those.
This uses .NET/WebAPI and ES6, and provides a skeleton for candidates to fill in with their suggestions for the implementation.

### The overall purpose of the BackEnd application is as follows:
1. To expose, via WebAPI, the titles of a number of books, as “GET /api/books”.
    * The books are stored as UTF8 text files in the Resources folder.
    
2. To allow a caller to retrieve the most common 10 words within an individual book.
 
    * The words are returned as a list of strings, from “GET /api/books/{id}”.

    * A word is defined as a sequence of non-whitespace, non-punctuation, non-special characters, we don't include words shorter than 5 letters in the top-10.

    * Case-matching is insensitive, and the top 10 words should be returned in Capital Case (e.g. “Word”)

3. The caller should then be able to send a string (min 3 characters), and receive back a list of all words which begin with that string from the specified book, e.g. “GET /api/books/1?query=Wha”.

    * Case-matching is insensitive.

    * The logic encapsulated by these calls should be supported and verified by at least one unit test.

**_NOTE:_ Assume that the list of books - and the contents of each book - will not change for the duration of the user session.**


### The UI calls the WebAPI API detailed above:
1. To retrieve the book titles, these are displayed to the user as HTML DOM elements added to the document tree.
2. When the user clicks on a book title, we retrieve the most common 10 words in that book and display them, and the count of those words’ usage.
3. The user can also type in a string (min 3 characters) into a search box. The UI will request all words which start with that prefix and display those in the same manner as the “top 10” above.

The code you send will be assessed on architecture, clean coding and how you’ve approached what you’ve attempted. Obviously, the more that a candidate attempts, the more we have to judge on, but we are aware that many candidates may have limited time, and we would prefer a few things done well, than a larger number done badly.

Please mention any known issues in your mail.

Please also consider what further improvements and enhancements you would have made to the solution if time was not a factor. This, and any questions arising from your code sample will provide the starting point for any further interview.
