function ChangingImage(input) {


    let [file] = input.files
    let blah = document.querySelector('#blah');

    if (file) {
        blah.classList.remove('img--none')
        blah.src = URL.createObjectURL(file)
    }
    else {
        blah.classList.add('img--none')
    }

}

const validateProjectsCard = new JustValidate('#Form-projets');


validateProjectsCard.addField('#textTitle', [
    {
        rule: 'required',
        errorMessage: 'Поле заголовка не должно быть пустым',
    },
    {
        rule: 'customRegexp',
        value: /^[а-яА-Яa-zA-Z0-9.,&?!()_\s\-]+$/gi,
        errorMessage: 'заголовка должен быть на русском или английском языке а также символы .,&?!()_'
    },
    {
        rule: 'minLength',
        value: 7,
        errorMessage: "В заголовке мало симвлов"
    },
    {
        rule: 'maxLength',
        value: 70,
        errorMessage: "В заголовке много символов"
    }
]);

validateProjectsCard.addField('#textDescrit', [
    {
        rule: 'required',
        errorMessage: 'Поле текста не должно быть пустым',
    },
    {
        rule: 'minLength',
        value: 7,
        errorMessage: "В тексте мало симвлов"
    }
]);

validateProjectsCard.addField('#file', [
    {
        rule: 'maxFilesCount',
        value: 1,
        errorMessage: 'Не больше 1 файла'
    },
    {
        rule: 'files',
        value: {
            files: {
                extensions: ['jpeg', 'jpg', 'png'],
                types: ['image/jpeg', 'image/jpg', 'image/png'],
            }
        },
        errorMessage: 'Файл должен быть формата jpeg, jpg, png'
    },
]);


validateProjectsCard.onSuccess(event => {

    let fileBit = [];

    SumbitForm(fileBit).then((e) => {

        if (fileBit.length < 1) {
            fileBit.push("");
        }


        $.ajax({
            type: "put",
            url: 'Edit',
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            data: JSON.stringify(
                {
                    Alt: document.querySelector('#blah').alt,
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

function readFile(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();

        reader.onload = res => {
            resolve(res.target.result);
        };
        reader.onerror = err => reject(err);

        reader.readAsArrayBuffer(file);
    });
}

async function SumbitForm(fileBit) {

    const input = document.querySelector('[name="file"]');

    let title = document.querySelector('#blah').alt.split("*")[0];

    if (input.files[0] != null) {
        let result = await readFile(input.files[0]);

        let str = ConvertArrayInStr(result);

        let fileName = input.files[0].name;
        let fileType = fileName.split('.');

        str += '.' + title + '.' + fileType[(fileType.length - 1)];

        fileBit.push(str);
    }
}

function ConvertArrayInStr(item) {
    var arrayBuffer = item,
        array = new Uint8Array(arrayBuffer);

    let fileByteArray = [];

    for (var i = 0; i < array.length; i++) {
        fileByteArray.push(array[i]);

    }



    return String(fileByteArray);
}
