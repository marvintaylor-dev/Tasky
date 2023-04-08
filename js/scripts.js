
function saveOnEnter() {
    let saveBtn = document.querySelector("#saveButton");
    let editBtn = document.querySelector("#editButton");


    document.querySelector("#taskInput").addEventListener("keyup", function (event) {
        // If the user presses the "Enter" key on the keyboard
        if (event.key === "Enter" && saveBtn) {
            console.log("Clicked Enter with Save Button")
            event.preventDefault();
            // Trigger the button element with a click
            saveBtn.click();
        }
        else if (event.key === "Enter" && editBtn) {
            console.log("Clicked Enter with Edit Button.")
            event.preventDefault();
            editBtn.click()
        }
        else {
            console.log("Clicked Enter with Nothing selected.")
        }
    });
}


function FocusAsync() {
    //give time for taskInput to load
    setTimeout(function () {
        document.querySelector("#taskInput").focus();
    }, 50)
};


