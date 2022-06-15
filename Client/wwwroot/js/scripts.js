
function saveOnEnter() {
    let saveBtn = document.querySelector("#saveButton");
    let editBtn = document.querySelector("#editButton");
    document.querySelector("#taskInput").addEventListener("keypress", function (event) {
                // If the user presses the "Enter" key on the keyboard
                if (event.key === "Enter" && saveBtn) {
                    event.preventDefault();
                    // Trigger the button element with a click
                    saveBtn.click();
                }
                else {
                    event.preventDefault();
                    editBtn.click()
                }
            });
}


