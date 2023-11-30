// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const setUpPalletList = () => {
    const addNewListElement = (water, size, currentIndex, palletNumber, outputList) => {
        const newElement = document.createElement('li');
        newElement.classList.add('list-group-item', 'input-group');
        newElement.textContent = `${water}, ${size}`;

        const removeButton = document.createElement('button');
        removeButton.classList.add('btn', 'btn-outline-danger');
        removeButton.type = 'button';
        removeButton.textContent = 'Remove';
        removeButton.addEventListener('click', () => {
            outputList.removeChild(newElement);
            form.removeChild(document.querySelector(`[name="PalletDtos[${currentIndex}].WaterId"]`));
            form.removeChild(document.querySelector(`[name="PalletDtos[${currentIndex}].PalletSize"]`));

            for (const pallet of form.querySelectorAll('input[name^="PalletDtos"]')) {
                const name = pallet.getAttribute('name');
                const index = parseInt(name.slice(name.indexOf('[') + 1, name.indexOf(']')));
                if (index > currentIndex) {
                    pallet.setAttribute('name', name.replace(index.toString(), (index - 1).toString()));
                }
            }

            palletNumber.value = parseInt(palletNumber.value) - 1;
        });
        newElement.insertAdjacentElement('beforeend', removeButton);
        outputList.insertAdjacentElement('beforeend', newElement);

        return newElement;
    };
    
    const addButton = document.getElementById('addPallet');
    const sizeInput = document.getElementById('palletSize');
    const waterSelect = document.getElementById('waterType');
    const palletNumber = document.getElementById('palletNumber');
    const outputList = document.getElementById('outputList');
    const form = document.querySelector('#delivery-form');

    addButton.addEventListener('click', () => {
        const water = waterSelect.options[waterSelect.selectedIndex].textContent;
        const size = parseInt(sizeInput.value);

        if (size <= 0 || isNaN(size)) return;
        const currentIndex = parseInt(palletNumber.value);
        palletNumber.value = parseInt(palletNumber.value) + 1;
        
        addNewListElement(water, size, currentIndex, palletNumber, outputList);

        form.insertAdjacentHTML('beforeend', `<input type="hidden" name="PalletDtos[${currentIndex}].WaterId" value="${waterSelect.value}"/>`);
        form.insertAdjacentHTML('beforeend', `<input type="hidden" name="PalletDtos[${currentIndex}].PalletSize" value="${size}"/>`);
    });
};

const setUpSaleEntryList = () => {
    const addButton = document.getElementById('addSaleEntry');
    const sizeInput = document.getElementById('waterQuantity');
    const waterSelect = document.getElementById('waterType');
    const outputList = document.getElementById('outputList');
    const form = document.querySelector('#sale-form');
    let numberOfEntries = 0;
    
    addButton.addEventListener('click', () => {
        const water = waterSelect.options[waterSelect.selectedIndex].textContent;
        const size = parseInt(sizeInput.value);

        if (size <= 0 || isNaN(size)) return;
        const currentIndex = numberOfEntries;
        numberOfEntries++;

        const newElement = document.createElement('li');
        newElement.classList.add('list-group-item', 'input-group');
        newElement.textContent = `${water}, ${size}`;

        const removeButton = document.createElement('button');
        removeButton.classList.add('btn', 'btn-outline-danger');
        removeButton.type = 'button';
        removeButton.textContent = 'Remove';
        removeButton.addEventListener('click', () => {
            outputList.removeChild(newElement);
            form.removeChild(document.querySelector(`[name="SaleEntryDtos[${currentIndex}].WaterId"]`));
            form.removeChild(document.querySelector(`[name="SaleEntryDtos[${currentIndex}].Quantity"]`));

            for (const saleEntry of form.querySelectorAll('input[name^="SaleEntryDtos"]')) {
                const name = saleEntry.getAttribute('name');
                const index = parseInt(name.slice(name.indexOf('[') + 1, name.indexOf(']')));
                if (index > numberOfEntries) {
                    saleEntry.setAttribute('name', name.replace(index.toString(), (index - 1).toString()));
                }
            }

            numberOfEntries--;
        });
        newElement.insertAdjacentElement('beforeend', removeButton);
        outputList.insertAdjacentElement('beforeend', newElement);

        form.insertAdjacentHTML('beforeend', `<input type="hidden" name="SaleEntryDtos[${currentIndex}].WaterId" value="${waterSelect.value}"/>`);
        form.insertAdjacentHTML('beforeend', `<input type="hidden" name="SaleEntryDtos[${currentIndex}].Quantity" value="${size}"/>`);
    });
}
