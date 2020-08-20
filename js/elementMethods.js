window.elementMethods = {
    getTextContent: (element) => {
        return element.textContent;
    },
    removeClass: (element, className) => {
        element.classList.remove(className)
    },
    addClass: (element, className) => {
        element.classList.add(className);
    },
    resetClass: (element, className) => {
        //removing and adding again through JSInterop doesnt work for some reason
        element.classList.remove(className);
        setTimeout(() => {
            element.classList.add(className);
        })
    }
}