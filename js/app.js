
import { getBookList } from "/js/modules/book.js";
import { defaultBookSearch, bookSearch } from "/js/modules/searchresults.js";


class App {

    constructor() {
        // retrieve list of books

        getBookList();
    }

    go() {

        // serach results functionality

        defaultBookSearch();

        bookSearch();
    }
}

new App().go();