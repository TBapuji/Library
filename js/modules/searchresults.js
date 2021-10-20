
export { defaultBookSearch, bookSearch }
import { createNode, append } from "/js/helpers/library.js";
import { lets, consts } from "/js/helpers/globals.js";

function defaultBookSearch() {
    //const ul = document.getElementById('booklist');
    //const ulresults = document.getElementById('resultlist');
    consts.ul.addEventListener('click', (e) => {
        
        
        var idval = e.target.closest('span');
        let id = idval.getAttribute('id');

        consts.ulresults.innerHTML = '';
        resultspane.style.visibility = 'visible';

        resultsbanner.innerHTML = 'Loading...';

        lets.librarySearchUrl = consts.libraryUrl + id;// + searchString;

        fetch(lets.librarySearchUrl, { referrer: "librarySearchUrl", referrerPolicy: "unsafe-url" })
            .then((resp) => {
                lets.referrerUrl = resp.url;
                return resp.json();
            })
            .then(function (data) {
                let resultlist = data;
                return resultlist.map(function (data) {
                    let li = createNode('li');
                    let span = createNode('span');
                    span.innerHTML = `${data.Word} ${data.Count}`;
                    append(li, span);
                    append(consts.ulresults, li);
                    resultsbanner.innerHTML = `Most common words in "${idval.innerHTML}"`;
                })
            })
            .catch(function (error) {
                resultsbanner.innerHTML = 'Sorry, an error occurred.';
                console.log(`error...  ${error}`);
            });
    });
}

function bookSearch() {
    let search = document.getElementById('search');
    search.addEventListener('keyup', (e) => {

        const searchString = e.target.value.toLowerCase();
        if (searchString.length > 2) {

            lets.librarySearchUrl = `${lets.referrerUrl}/${searchString}`;
            consts.ulresults.innerHTML = '';
            fetch(lets.librarySearchUrl)
                .then((resp) => resp.json())
                .then(function (data) {
                    let resultlist = data;
                    return resultlist.map(function (data) {
                        let li = createNode('li');
                        let span = createNode('span');
                        span.innerHTML = `${data.Word} ${data.Count}`;
                        append(li, span);
                        append(consts.ulresults, li);
                    })
                })
                .catch(function (error) {
                    console.log(`error...  ${error}`);
                });
        }

    })
}