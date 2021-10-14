////this could also be called serach.js perhaps?

export { searchresults }
import { createNode, append } from "/js/helpers/library.js";

//let search = document.getElementById('search');

class searchresults {
    resultsList() { console.log('this is from the searchresults class:resultsList()'); }

    // put a message if no results were returned

    //do a fetch request here to get the list of results


}

const ul = document.getElementById('resultlist');

export function displayBooks(x) {
    let li = createNode('li');
    let span = createNode('span');
    let divEmail = createNode('div');
    span.innerHTML = `${x.name.first} ${x.name.last}, ${x.name.title}`;
    divEmail.innerHTML = `${x.email}`;
    append(li, span);
    append(li, divEmail);
    append(ul, li);
}