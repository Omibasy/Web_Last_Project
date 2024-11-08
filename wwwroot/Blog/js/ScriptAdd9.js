

validateProjectsCard.addField('#DateCard', [
    
    {
        plugin: JustValidatePluginDate(() => ({
            required: true,
            isAfter: '01/01/2010',

        })),
        errorMessage: 'Укажите дату не поже (01.01.2010)',
    },
    

]);

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
                    dateTime: document.querySelector('#DateCard').value,
                    Alt: document.querySelector('#textAlt').value,
                    Description: document.querySelector('#textDescrit').value,
                    Title: document.querySelector('#textTitle').value,
                    file: fileBit[0]
                }
            ),

            success: function (msg) {

                if (msg == 'successfully') {
                    window.location.href = "/Blog/Editable";
                }
                else {
                    window.location.href = "/Exception/Mistake";
                }
            }
        });
    });
});