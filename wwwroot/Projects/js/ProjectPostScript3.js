validateProjectsCard.onSuccess(event => {

    let fileBit = [];


    SumbitForm(fileBit).then((e) => {

        if (fileBit.length < 1) {
            fileBit.push("");
        }

        $.ajax({
            type: "post",
            url: 'Set',
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            data: JSON.stringify(
                {
                    Alt: document.querySelector('#textAlt').value,
                    Description: document.querySelector('#textDescrit').value,
                    Title: document.querySelector('#textTitle').value,
                    file: fileBit[0]
                }
            ),

            success: function (msg) {

                if (msg == 'successfully') {
                    window.location.href = "/Projects/Editable";
                }
                else {
                    window.location.href = "/Exception/Mistake";
                }
            }
        });
    });
});