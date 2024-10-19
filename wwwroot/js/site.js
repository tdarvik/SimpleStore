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