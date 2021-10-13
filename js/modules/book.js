﻿export { book, getBookList }
import { createNode, append } from "/js/helpers/library.js";
import { urls } from "/js/helpers/settings.js";

class book {
    hi() { console.log('this is from the book class:hi()'); }

    //do a fetch request here to get the books
}


function getBookList() {

    let bookUrl = 'http://localhost:49265/api/books';

    let ul = document.getElementById('booklist');
    //booklist.innerHTML = "<span>HELLO</span>";

    fetch(bookUrl)
        .then((resp) => resp.json())
        .then(function (data) {
            console.log(data);
            let booklist = data;
            console.log(booklist[0].FileName);
            // make into function displayBooks() and put in sep file. Also displayResults()
            return booklist.map(function (data) {
                let li = createNode('li');
                let span = createNode('span');
                let a = createNode('a');
                a.href = `${bookUrl}/${data.ID}`;
                a.innerHTML = `${data.ID} ${data.Title}`;
                append(span, a);
                append(li, span);
                append(ul, li);
            })
        })
        .catch(function (error) {
            console.log(`error...  ${error}`);
        });
    
    //const books = ['A Tale Of Two Cities', 'A Tale Of Two Cities', 'The Hound Of The Baskervilles'];

    //return books;
}