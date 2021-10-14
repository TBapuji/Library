// import Something from "./another-js-file.js";

import { createNode, append } from "/js/helpers/library.js";


import { getBookList } from "/js/modules/book.js";
//import { displayBooks } from "/js/modules/searchresults.js";

//const db = displayBooks;


//let libraryUrl = 'https://hp-api.herokuapp.com/api/characters';

//let libraryUrl = 'https://randomuser.me/api/?results=10';
let libraryUrl = 'http://localhost:49265/api/books/1/';


const ul = document.getElementById('resultlist');

class App {

    constructor() {
        // setup - WHAT TO PUT HERE? IS THIS WHERE WE LOAD THE BOOK LISTS? maybe not - it suggests otherwise in the go function
        // google- "what do you put in the constructor of app.js"
    }

    go() {


        // retrieve and display the list of books

        // here you can do that mappy loopy business with append ul, li, span etc
        // then either append to the container element in the html file, or add the concatenated string to the innerHTML

        let list = getBookList();
        console.log(list);


    }
}

search.addEventListener('keyup', (e) => {

    const searchString = e.target.value.toLowerCase();
    let librarySearchUrl = libraryUrl + searchString;
    console.log(librarySearchUrl);
    ul.innerHTML = '';
    fetch(librarySearchUrl)
        .then((resp) => resp.json())
        .then(function (data) {
            let resultlist = data;
            return resultlist.map(function (data) {
                let li = createNode('li');
                let span = createNode('span');
                span.innerHTML = `${data.Word} ${data.Count}`;
                append(li, span);
                append(ul, li);
            })
        })
        .catch(function (error) {
            //      resultsbanner.innerHTML = 'Sorry, an error occurred.';
            console.log(`error...  ${error}`);
        });
})
new App().go();