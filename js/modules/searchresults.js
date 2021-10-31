
export { defaultBookSearch, bookSearch }
import { createNode, append } from "/js/helpers/library.js";
import { lets, consts } from "/js/helpers/globals.js";

function defaultBookSearch() {
    consts.ul.addEventListener('click', (e) => {

        search.value = '';

        let idval = e.target.closest('span');
        let id = idval.getAttribute('id');

        localStorage.bookTitle = idval.innerHTML;

        consts.ulresults.innerHTML = '';
        resultspane.style.visibility = 'visible';

        resultsbanner.innerHTML = 'Loading...';

        //lets.librarySearchUrl = consts.libraryUrl + id;// + searchString;
        localStorage.lastBookUrl = consts.libraryUrl + id;
        fetchSearchResults(localStorage.lastBookUrl);
    });
}

function listSearchResults(data, str) {
    let li = createNode('li');
    let span = createNode('span');
    span.innerHTML = `${data.Word} ${data.Count}`;
    append(li, span);
    append(consts.ulresults, li);
    resultsbanner.innerHTML = `Most common words in "${str}"`;
}
function bookSearch() {
    let search = document.getElementById('search');
    search.addEventListener('keyup', (e) => {

        const searchString = e.target.value.toLowerCase();
        if (searchString.length > consts.searchStringLength) {

            lets.librarySearchUrl = `${localStorage.lastBookUrl}/${searchString}`;
            consts.ulresults.innerHTML = '';
            //console.log(`lets.librarySearchUrl  ${lets.librarySearchUrl}`);
            fetchSearchResults(lets.librarySearchUrl);
        }
    })
}

function fetchSearchResults(url) {
    fetch(url)
        .then((resp) => {
            return resp.json();
        })
        .then(data => data.map(data => listSearchResults(data, localStorage.bookTitle))
        )
        .catch(function (error) {
            resultsbanner.innerHTML = 'Sorry, an error occurred.';
            console.log(`error...  ${error}`);
        });
}