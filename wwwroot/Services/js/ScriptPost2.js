validateProjectsCard.onSuccess(event => {

    $.ajax({
        type: "post",
        url: 'Set',
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        data: JSON.stringify(
            {
                Description: document.querySelector('#textDescrit').value,
                Title: document.querySelector('#textTitle').value,
            }
        ),

        success: function (msg) {

            if (msg == 'successfully') {
                window.location.href = "/Services/Change";
            }
            else {
                window.location.href = "/Exception/Mistake";
            }
        }
    });

});