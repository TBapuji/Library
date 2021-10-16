export function createNode(element) {
    return document.createElement(element);
}

export function append(parent, el) {
    return parent.appendChild(el);
}

export function setNodeId(element, id) {
    element.id = id;
}

export function setClassName(element, className) {
    element.className.append = className;
}