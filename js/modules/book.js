export { getBookList }
import { createNode, setClassName, append } from "/js/helpers/library.js";


function getBookList() {

    let bookUrl = 'http://localhost:49265/api/books';

    let ul = document.getElementById('booklist');
    //booklist.innerHTML = "<span>HELLO</span>";

    fetch(bookUrl, { referrer: "librarySearchUrl", referrerPolicy: "unsafe-url" })
        .then((resp) => resp.json())
        .then(function (data) {
            let booklist = data;
            return booklist.map(function (data) {
                let li = createNode('li');
                let span = createNode('span');
                span.innerHTML = `${data.Title}`;
                span.id = `${data.ID}`;
                append(ul, li);
                append(li, span);
            })
        })
        .catch(function (error) {
            console.log(`error...  ${error}`);
        });
}

