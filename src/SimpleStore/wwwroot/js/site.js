document.addEventListener('DOMContentLoaded', () => {
    fetchItems();

    const form = document.getElementById('addItemForm');
    form.addEventListener('submit', function (event) {
        event.preventDefault();
        addItem();
    });
});

function fetchItems() {
    fetch('/api/store')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const tableBody = document.getElementById('itemTableBody');
            tableBody.innerHTML = '';
            data.forEach(item => {
                const row = document.createElement('tr');

                row.innerHTML = `
                <td>${item.name}</td>
                <td>${item.description}</td>
                <td>${item.price},-</td>
                <td class="actions"><button onclick="deleteItem('${item.id}')">Delete</button></td>
            `;
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
}

function deleteItem(id) {
    fetch(`/api/store/${id}`, {
        method: 'DELETE'
    }).then(response => {
        if (response.ok) fetchItems();
    });
}

function addItem() {
    if (!validInput()) return;
    const editorValues = getEditorValues();
    fetch('/api/store', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            name: editorValues[0].value,
            description: editorValues[1].value,
            price: Number(editorValues[2].value),
        })
    }).then(res => {
        if (res.ok) {
            fetchItems();
            resetEditor();
        };
    });
}

function checkIfAddPossible() {
    document.getElementById("add-item-button").disabled = !validInput();
}

function validInput() {
    const editorValues = getEditorValues();
    return editorValues.map(e => e.value).filter(e => e !== null).length === 3;
}

function getEditorValues() {
    return ["editor-name", "editor-description", "editor-price"].map(e => (
        { name: e, value: getEditorValue(e) }
    ));
}

function getEditorValue(editorId) {
    const value = document.getElementById(editorId).value;
    if (value) return value;
    return null;
}

function resetEditor() {
    ["editor-name", "editor-description", "editor-price"].map(e => document.getElementById(e).value = "");
}