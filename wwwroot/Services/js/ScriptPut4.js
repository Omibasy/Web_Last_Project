validateProjectsCard.onSuccess(event => {

    let href = window.location.href.split('=');

    let count = href[href.length - 1];

    $.ajax({
        type: "put",
        url: 'Edit',
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        data: JSON.stringify(
            {
                Description: document.querySelector('#textDescrit').value,
                Title: document.querySelector('#textTitle').value + "*" + count,
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