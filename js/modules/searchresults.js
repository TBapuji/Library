////this could also be called serach.js perhaps?

export { searchresults }
import { createNode, append } from "/js/helpers/library.js";

let libraryUrl = 'http://localhost:49265/api/books/1/';

//let search = document.getElementById('search');

class searchresults {
    resultsList() { console.log('this is from the searchresults class:resultsList()'); }

    // put a message if no results were returned

    //do a fetch request here to get the list of results


}


export function displayBooks() {
    search.addEventListener('keyup', (e) => {

        const searchString = e.target.value.toLowerCase();
        console.log(`In searchresult.js ${libraryUrl}${searchString}`);
        let librarySearchUrl = libraryUrl + searchString;

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
}