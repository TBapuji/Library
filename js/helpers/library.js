export function createNode(element) {
    return document.createElement(element);
}

export function append(parent, el) {
    return parent.appendChild(el);
}