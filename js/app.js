// import Something from "./another-js-file.js";


import { getBookList } from "/js/modules/book.js";
import { displayBooks } from "/js/modules/searchresults.js";

const db = displayBooks;

//const db = function displayBooks(x) {
//    let li = createNode('li');
//    let span = createNode('span');
//    let divEmail = createNode('div');
//    span.innerHTML = `${x.name.first} ${x.name.last}, ${x.name.title}`;
//    divEmail.innerHTML = `${x.email}`;
//    append(li, span);
//    append(li, divEmail);
//    append(ul, li);
//}
//let libraryUrl = 'https://hp-api.herokuapp.com/api/characters';

//let libraryUrl = 'https://randomuser.me/api/?results=10';
let libraryUrl = 'http://localhost:49265/api/books/1';



//var book1 = new book();
//book1.hi();

//let results = new searchresults();
//results.resultsList();

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

        // would the text input addEventListener go in this file?

        search.addEventListener('keyup', (e) => {

            const searchString = e.target.value.toLowerCase();
            console.log(`search.addEventListener ${searchString}`);

            //return resultlist.map(function (item) {
            //    let li = createnode('li');
            //    let span = createnode('span');
            //    span.innerhtml = `${item}`;
            //    append(li, span);
            //    append(ul, li);

            fetch(libraryUrl)
                .then((resp) => resp.json())
                .then(function (data) {
                    let resultlist = data.results;
                    //console.log(resultlist.toString());
                    // make into function displayBooks() and put in sep file. Also displayResults()
                    return resultlist.map(db)
                })
                .catch(function (error) {
                    console.log(`error...  ${error}`);
                });
        })

    }
}

new App().go();