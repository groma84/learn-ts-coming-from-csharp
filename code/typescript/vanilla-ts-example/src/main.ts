import './style.css'

// wait until everything is loaded
window.onload = () => {
    // select elements via id
    const saveButton = document.querySelector('#save');
    const todoInput: HTMLInputElement | null = document.querySelector('#todo');
    const todosList = document.querySelector('#todos-list');

    if (saveButton && todoInput && todosList) {
        saveButton.addEventListener('click', () => {
            // get value and append new list item to list
            const todoText = todoInput.value;
            if (todoText) {
                const li = document.createElement('li');
                li.innerHTML = todoText;
                todosList.appendChild(li);

                // reset input value
                todoInput.value = "";
            }
        });
    }
}
