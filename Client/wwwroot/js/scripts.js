


function saveOnEnter() {
    
            document.querySelector("#taskInput").addEventListener("keypress", function(event) {
            // If the user presses the "Enter" key on the keyboard
                if (event.key === "Enter") {
                  // Trigger the button element with a click
                    document.querySelector("#saveButton").click();
                }
            });
}